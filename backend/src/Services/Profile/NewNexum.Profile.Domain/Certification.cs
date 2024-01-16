using System;

namespace NewNexum.Profile.Domain
{
    public class Certification
    {
        public Guid CertificationID { get; private set; }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public string IssuingOrganization { get; private set; }

        public DateTime DateOfIssue { get; private set; }

        public DateTime? ExpirationDate { get; private set; }

        public string CredentialCode { get; private set; }

        public string CredentialURL { get; private set; }

        public DateTime DateAdded { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public Certification(string name, string issuingOrganization, string userId)
        {
            CertificationID = Guid.NewGuid();
            Name = name;
            IssuingOrganization = issuingOrganization;
            UserId = userId;
        }
        
        public static Certification Create(
            string name,
            string issuingOrganization,
            string userId)
        {
            var certification = new Certification(
                name,
                issuingOrganization,
                userId);

            return certification;
        }
    }
}
