using Microsoft.AspNetCore.Authentication;
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

            IPermissionService permissionService = scope.ServiceProvider.GetService<IPermissionService>();
                   // ?? throw new Exception("Não foi possiveil iniciar o serviço de permissões");

            string identityId = principal.GetUserIdentityId();

            var permissions = permissionService.GetUserPermissionsAsync(identityId);

            return principal;
        }
    }
}
