using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;
using NewNexum.Core.User;
using NewNexum.Users.Domain.User;
using NewNexum.WebApi.Core.Authorization;

namespace NewNexum.Users.Application.Users.Queries.GetUserPermissions
{
    internal class GetUserPermissionQueryHandler(IUserRepository _userRepository) : IQueryHandler<GetUserPermissionQuery, PermissionsResponse>
    {
        public async Task<Result<PermissionsResponse>> Handle(GetUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var identityId = request.identityId;

            var userPermissions = await _userRepository.GetUserPermission(identityId);

            if (!userPermissions.Any())
            {
                return Result.Failure<PermissionsResponse>(UserErrors.NotFound(identityId));
            }

            return new PermissionsResponse(userPermissions.First().UserId, userPermissions.Select(permission => permission.Permission).ToHashSet());
        }
    }
}
