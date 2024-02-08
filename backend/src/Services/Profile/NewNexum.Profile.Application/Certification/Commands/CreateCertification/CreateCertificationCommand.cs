using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;


namespace NewNexum.Profile.Application.Certification.Commands.CreateCertification
{
    public class CreateCertificationCommand : ICommand<Result>
    {
        public CreateCertificationCommand(string name, string issuingOrganization, DateTime? dateOfIssue, DateTime? expirationDate, string credentialCode, string credentialURL)
        {
            Name = name;
            IssuingOrganization = issuingOrganization;
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            CredentialCode = credentialCode;
            CredentialURL = credentialURL;
        }

        public string Name { get; private set; }

        public string IssuingOrganization { get; private set; }

        public DateTime? DateOfIssue { get; private set; }

        public DateTime? ExpirationDate { get; private set; }

        public string CredentialCode { get; private set; }

        public string CredentialURL { get; private set; }
    }
}
