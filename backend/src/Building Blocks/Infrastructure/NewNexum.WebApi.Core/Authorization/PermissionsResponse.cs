namespace NewNexum.WebApi.Core.Authorization
{
    public record PermissionsResponse(Guid userId, HashSet<string> Permissions);
}
