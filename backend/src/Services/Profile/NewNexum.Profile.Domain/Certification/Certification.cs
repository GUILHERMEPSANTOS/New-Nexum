using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;
using NewNexum.Core.DomainObjects;
using NewNexum.Core.ValueObjects;
using System.Security.Claims;
using System.Xml.Linq;

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

        public Url CredentialURL { get; private set; }

        public DateTime? DateAdded { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        private Certification(
            string userId,
            string name,
            string issuingOrganization,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            Url credentialURL = null) : base()
        {
            UserId = userId;
            Name = name;
            IssuingOrganization = issuingOrganization;
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            CredentialCode = credentialCode;
            CredentialURL = credentialURL;
            DateAdded = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        public static Certification Create(
            string userId,
            string name,
            string issuingOrganization,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            Url credentialURL = null)
        {
            var certification = new Certification(
                userId,
                name,
                issuingOrganization,
                dateOfIssue,
                expirationDate,
                credentialCode,
                credentialURL);            

            return certification;
        }


        public Result Update(
            string name = null,
            string issuingOrganization = null,
            DateTime? dateOfIssue = null,
            DateTime? expirationDate = null,
            string credentialCode = null,
            Url credentialURL = null)
        {
            if(dateOfIssue is not null && dateOfIssue > expirationDate)
            {
                return Result.Failure(CertificationErrors.DateOfIssueMustBeEarlierThanExpirationDate);
            }

            if (!string.IsNullOrEmpty(name) && name != Name)
            {
                Name = name;
            }

            if (!string.IsNullOrEmpty(issuingOrganization) && issuingOrganization != IssuingOrganization)
            {
                IssuingOrganization = issuingOrganization;
            }
            
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            CredentialCode = credentialCode;
            CredentialURL = credentialURL;
            UpdateDate = DateTime.UtcNow;

            return Result.Success();
        }
    }
}
