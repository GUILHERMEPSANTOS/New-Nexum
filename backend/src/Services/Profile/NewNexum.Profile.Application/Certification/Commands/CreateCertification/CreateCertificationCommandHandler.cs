using Microsoft.AspNetCore.Http;
using NewNexum.Core.Communication;
using NewNexum.Core.Data;
using NewNexum.Core.Messaging;
using NewNexum.Core.User;
using NewNexum.Core.ValueObjects;
using NewNexum.Profile.Domain;
using System.Security.Claims;


namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    public class CreateCertificationCommandHandler : ICommandHandler<CreateCertificationCommand, Result>
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserIdentifierProvider _userIdentifierProvider;

        public CreateCertificationCommandHandler(ICertificationRepository certificationRepository, IUnitOfWork unitOfWork, IUserIdentifierProvider userIdentifierProvider)
        {
            _certificationRepository = certificationRepository;
            _unitOfWork = unitOfWork;
            _userIdentifierProvider = userIdentifierProvider;
        }

        public async Task<Result> Handle(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            var userId = _userIdentifierProvider.GetUserIdentifier();
            var credentialUrl = ValidateAndCreateUri(request.CredentialURL);

            if (credentialUrl.IsFailure)
            {
                return Result.Failure(credentialUrl.Error);
            }

            if (CheckDateOfIssueIsBeforeExpirationDate(request))
            {
                return Result.Failure(CertificationErrors.DateOfIssueMustBeEarlierThanExpirationDate);
            }

            var certification = Domain.Certification.Create(
                userId: userId,
                name: request.Name,
                issuingOrganization: request.IssuingOrganization,
                dateOfIssue: request.DateOfIssue,
                expirationDate: request.ExpirationDate,
                credentialCode: request.CredentialCode,
                credentialURL: credentialUrl.Value
            );

            _certificationRepository.Insert(certification);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        private Result<Url> ValidateAndCreateUri(string credentialUrl)
        {
            if (string.IsNullOrEmpty(credentialUrl))
                return Result.Success<Url>(default);

            return Url.Create(credentialUrl);
        }

        private bool CheckDateOfIssueIsBeforeExpirationDate(CreateCertificationCommand request)
            => request.DateOfIssue is not null
                && request.ExpirationDate is not null
                && request.DateOfIssue > request.ExpirationDate;
    }
}
