using Microsoft.Extensions.Logging;
using NewNexum.Core.Communication;
using NewNexum.Users.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.IdP.Keycloak
{
    public class IdentityProviderKeycloakService(KeyCloakClient keyCloakClient) : IIdentityProviderService
    {
        private const string PasswordCredentialType = "Password";

        public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
        {
            var userRepresentation = new UserRepresentation(
                user.Email,
                user.Email,
                user.FirstName,
                user.LastName,
                true,
                true,
                [new CredentialRepresentation(PasswordCredentialType, user.Password, false)]
             );
                     
            Result<string> identityId = await keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);
            
            return identityId;
        }
    }
}
