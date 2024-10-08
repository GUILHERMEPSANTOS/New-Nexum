using MediatR;
using Microsoft.AspNetCore.Http;
using NewNexum.Core.Communication;
using NewNexum.Users.Application.Users.Queries.GetUserPermissions;
using NewNexum.WebApi.Core.Authorization;

namespace NewNexum.Users.Application.Authorization
{
    public class PermissionService(IMediator _mediator, IHttpContextAccessor httpContextAccessor) : IPermissionService
    {
        public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
        {
            var context = httpContextAccessor.HttpContext.User;

            return await _mediator.Send(new GetUserPermissionQuery(identityId));
        }
    }
}