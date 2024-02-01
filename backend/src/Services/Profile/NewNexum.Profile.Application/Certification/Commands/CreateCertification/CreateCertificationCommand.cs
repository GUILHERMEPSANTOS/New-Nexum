using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;
using NewNexum.Core.ValueObjects;

namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    public class CreateCertificationCommand : ICommand<Result>
    {
        public string Name { get; private set; }

        public string IssuingOrganization { get; private set; }

        public DateTime? DateOfIssue { get; private set; }

        public DateTime? ExpirationDate { get; private set; }

        public string CredentialCode { get; private set; }

        public string CredentialURL { get; private set; }
    }
}
