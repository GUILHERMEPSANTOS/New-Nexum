using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using NewNexum.Core.User;

namespace NewNexum.WebApi.Core.User
{
    public sealed class UserIdentifierProvider : IUserIdentifierProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpContext Context => _httpContextAccessor?.HttpContext;

        public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserIdentifier()
        {
            return Context?.User?.Claims?
                    .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value ?? "";
        }
    }
}
