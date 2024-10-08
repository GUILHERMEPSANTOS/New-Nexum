using Microsoft.AspNetCore.Http;

namespace NewNexum.Profile.Application.Authorization
{
    public class PermissionDelegatingHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = httpContextAccessor?.HttpContext
                   ?? throw new Exception("invalid context!");

            var authorizationHeader = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                request.Headers.Add("Authorization", values: new List<string> { authorizationHeader });
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
