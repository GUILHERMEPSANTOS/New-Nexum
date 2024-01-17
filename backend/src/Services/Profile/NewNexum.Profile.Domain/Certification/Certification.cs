using NewNexum.Core.Communication;
using NewNexum.Core.DomainObjects;

namespace NewNexum.Profile.Domain
{
    public class Certification : Entity
    {
        public string UserId { get; private set; }

        public string Name { get; private set; }

        public string IssuingOrganization { get; private set; }

        public DateTime? DateOfIssue { get; private set; }

        public DateTime? ExpirationDate { get; private set; }

        public string CredentialCode { get; private set; }

        public string CredentialURL { get; private set; }

        public DateTime? DateAdded { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        private Certification(
            string userId,
            string name,
            string issuingOrganization,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            string credentialURL = null,
            DateTime? dateAdded = null,
            DateTime? updateDate = null
            ) : base()
        {
            UserId = userId;
            Name = name;
            IssuingOrganization = issuingOrganization;
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            CredentialCode = credentialCode;
            CredentialURL = credentialURL;
            DateAdded = dateAdded;
            UpdateDate = updateDate;
        }

        public static Certification Create(
            string userId,
            string name,
            string issuingOrganization,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            string credentialURL = null,
            DateTime? dateAdded = null,
            DateTime? updateDate = null
            )
        {
            var certification = new Certification(
                userId,
                name,
                issuingOrganization,
                dateOfIssue,
                expirationDate,
                credentialCode,
                credentialURL,
                dateAdded,
                updateDate);

            return certification;
        }


        public void Update(
            string name,
            string issuingOrganization,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            string credentialURL = null)
        {
        
            //Ensure.NotNull(name)
            //Ensure.NotNull(name)
           
            Name = name;
            IssuingOrganization = issuingOrganization;
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            CredentialCode = credentialCode;
            CredentialURL = credentialURL;
        }
    }
}
