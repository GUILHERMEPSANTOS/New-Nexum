using MediatR;
using NewNexum.Core.Communication;
using NewNexum.WebApi.Core.Authorization;
using System.Net.Http.Json;

namespace NewNexum.Profile.Application.Authorization
{
    public class PermissionService(HttpClient _httpClient) : IPermissionService
    {
        public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
        {
            var permission = await _httpClient.GetFromJsonAsync<PermissionsResponse>($"users/{identityId}/permissions");

            if (permission is null) return Result.Failure<PermissionsResponse>(Error.NullValue);

            return permission;
        }
    }
}
