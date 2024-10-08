using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewNexum.WebApi.Core.Authorization;
using System.Security.Claims;


namespace NewNexum.WebApi.Core.Authentication
{
    public class CustomClaimsTransformation(IServiceScopeFactory serviceScopeFactory) : IClaimsTransformation
    {
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.HasClaim(c => c.Type == CustomClaims.Sub))
            {
                return principal;
            }
           
            using var scope = serviceScopeFactory.CreateScope();

            IPermissionService permissionService = scope.ServiceProvider.GetService<IPermissionService>()
                    ?? throw new Exception("Unable to start the permissions service.");

            string identityId = principal.GetUserIdentityId();

            var permissions = await permissionService.GetUserPermissionsAsync(identityId);

            if(permissions.IsFailure) 
                throw new Exception("Unable to start the permissions service.");

            var claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(CustomClaims.Sub, permissions.Value.userId.ToString()));

            foreach (var permission in permissions.Value.Permissions)
            {
                claimsIdentity.AddClaim(new Claim(CustomClaims.Permission, permission));
            }

            principal.AddIdentity(claimsIdentity);

            return principal;
        }
    }
}
