using NewNexum.Core.Communication;

namespace NewNexum.WebApi.Core.Authorization
{
    internal interface IPermissionService
    {
        Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
    }
}
