using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.IdP
{
    internal static class IdentityProviderErrors
    {
        public static Error EmailIsNotUnique = new("Identity.EmailIsNotUnique", "The specified email is not unique.", ErrorType.Failure);
    }
}
