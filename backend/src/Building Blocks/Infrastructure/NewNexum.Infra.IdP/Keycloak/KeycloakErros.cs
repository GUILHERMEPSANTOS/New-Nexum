using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.IdP.Keycloak
{
    public static class KeycloakErros
    {
        public static Error FailureRegisterUser = new("User.FailureRegisterUser", "Failed to register user", ErrorType.Failure);
    }
}
