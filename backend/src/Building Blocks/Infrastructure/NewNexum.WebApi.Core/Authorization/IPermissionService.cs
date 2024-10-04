using NewNexum.Core.Communication;

namespace NewNexum.WebApi.Core.Authorization
{
    public interface IPermissionService
    {
        Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
    }
}
