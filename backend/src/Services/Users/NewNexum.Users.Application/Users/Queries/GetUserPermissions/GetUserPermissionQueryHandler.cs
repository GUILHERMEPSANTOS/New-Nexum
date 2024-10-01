using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;
using NewNexum.Users.Domain.User;
using NewNexum.WebApi.Core.Authorization;

namespace NewNexum.Users.Application.Users.Queries.GetUserPermissions
{
    internal class GetUserPermissionQueryHandler(IUserRepository _userRepository) : IQueryHandler<GetUserPermissionQuery, PermissionsResponse>
    {
        public async Task<Result<PermissionsResponse>> Handle(GetUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var userPermissions = await _userRepository.GetUserPermission(request.IdentityId);

            if (!userPermissions.Any())
            {
                return Result.Failure<PermissionsResponse>(UserErrors.NotFound(request.IdentityId));
            }

            return new PermissionsResponse(userPermissions.First().UserId, userPermissions.Select(permission => permission.Permission).ToHashSet());
        }
    }
}
