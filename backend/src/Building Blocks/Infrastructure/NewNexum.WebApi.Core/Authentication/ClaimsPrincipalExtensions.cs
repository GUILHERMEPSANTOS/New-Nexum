using System.Security.Claims;


namespace NewNexum.WebApi.Core.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserIdentityId(this ClaimsPrincipal? principal)
            => principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new Exception("User identity is unavailable");
    }
}
