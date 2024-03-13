using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authentication;

namespace NewNexum.WebApi.Core.Authentication.Claims
{
    public class KeycloakRolesClaimsTransformation : IClaimsTransformation
    {
        private readonly string _audience;

        public KeycloakRolesClaimsTransformation(string audience)
        {
            _audience = audience;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var result = principal.Clone();

            if (result.Identity is not ClaimsIdentity identiy)
            {
                return Task.FromResult(result);
            }

            var resourceAccessValue = principal.FindFirst("resource_access")?.Value;

            if (string.IsNullOrEmpty(resourceAccessValue))
            {
                return Task.FromResult(result);
            }

            using var resourceAccess = JsonDocument.Parse(resourceAccessValue);

            var clientRoles = resourceAccess
                    .RootElement
                    .GetProperty(_audience)
                    .GetProperty("roles");

            foreach (var role in clientRoles.EnumerateArray())
            {
                var value = role.GetString();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    identiy.AddClaim(new Claim(ClaimTypes.Role, value));
                }
            }

            return Task.FromResult(result);
        }
    }
}
