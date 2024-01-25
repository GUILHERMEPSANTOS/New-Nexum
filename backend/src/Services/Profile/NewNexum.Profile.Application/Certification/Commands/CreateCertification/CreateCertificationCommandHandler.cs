using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;
using NewNexum.Core.ValueObjects;
using NewNexum.Profile.Domain;


namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    public class CreateCertificationCommandHandler : ICommandHandler<CreateCertificationCommand, Result>
    {
        public async Task<Result> Handle(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            var credentialUrl = ValidateAndCreateUri(request.CredentialURL);

            if (credentialUrl.IsFailure)
            {
                return Result.Failure(credentialUrl.Error);
            }

            if (request.DateOfIssue is not null
                && request.ExpirationDate is not null
                && request.DateOfIssue > request.ExpirationDate)
            {
                return Result.Failure(CertificationErrors.DateOfIssueMustBeEarlierThanExpirationDate);
            }

            var certification = Domain.Certification.Create(
                userId: "", 
                name: request.Name,
                issuingOrganization: request.IssuingOrganization,
                dateOfIssue: request.DateOfIssue,
                expirationDate: request.ExpirationDate,
                credentialCode: request.CredentialCode,
                credentialURL: credentialUrl.Value              
            );


            return Result.Success();
        }

        public Result<Url> ValidateAndCreateUri(string credentialUrl)
        {
            if (string.IsNullOrEmpty(credentialUrl))
                return Result.Success<Url>(default);

            return Url.Create(credentialUrl);
        }
    }
}
