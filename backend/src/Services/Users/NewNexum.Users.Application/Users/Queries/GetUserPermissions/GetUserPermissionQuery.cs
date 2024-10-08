using NewNexum.Core.Messaging;
using NewNexum.WebApi.Core.Authorization;

namespace NewNexum.Users.Application.Users.Queries.GetUserPermissions
{
    public record GetUserPermissionQuery(string identityId) : IQuery<PermissionsResponse>;    
}
