using NewNexum.Core.Communication;
using NewNexum.Core.DomainObjects;
using NewNexum.Core.Messaging;
using NewNexum.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    public class CreateCertificationCommandHandler : ICommandHandler<CreateCertificationCommand, Result>
    {
        public async Task<Result> Handle(CreateCertificationCommand request, CancellationToken cancellationToken)
        {
            Result<Url> urlResult = Url.Create(request.CredentialURL);

            if (urlResult.IsFailure)
            {
                return urlResult;
            }

            return Result.Success();
        }
    }
}
