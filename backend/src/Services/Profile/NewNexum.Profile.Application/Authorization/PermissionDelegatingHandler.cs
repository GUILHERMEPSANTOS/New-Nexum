using Microsoft.AspNetCore.Http;

namespace NewNexum.Profile.Application.Authorization
{
    public  class PermissionDelegatingHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        protected override  async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = httpContextAccessor?.HttpContext
                   ?? throw new Exception("invalid context!");

            var token = context.Request.Headers["Authorization"];

 
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
