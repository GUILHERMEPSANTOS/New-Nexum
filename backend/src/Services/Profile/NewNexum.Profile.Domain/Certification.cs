using System;

namespace NewNexum.Profile.Domain
{
    public class Certification
    {
        public Guid CertificationID { get; private set; }

        public string userId { get; private set; }

        public string Name { get; private set; }
        
        public string IssuingOrganization { get; private set; }

        public DateTime DateOfIssue { get; private set; }
        
        public DateTime? ExpirationDate { get; private set; }
        
        public string CredentialCode { get; private set; }
        
        public string CredentialURL { get; private set; }

        public DateTime DateAdded { get; private set; }

        public DateTime UpdateDate { get; private set; }

    }
}
