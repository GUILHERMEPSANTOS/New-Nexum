using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Profile.Domain
{
    public static class CertificationErrors
    {
        public static Error NameCanNotBeEmpty => new("Certification.NameCanNotBeEmpty", "Name cannot be empty", ErrorType.Validation);
        public static Error IssuingOrganizationCanNotBeEmpty => new("Certification.IssuingOrganizationCanNotBeEmpty", "IssuingOrganization cannot be empty", ErrorType.Validation);
        public static Error DateOfIssueMustBeEarlierThanExpirationDate => new("Certification.DateOfIssueMustBeEarlierThanExpirationDate", " Date of issue must be earlier than the expiration date.", ErrorType.Validation);
    }
}
