using NewNexum.Core.Communication;

namespace NewNexum.Users.Domain.User
{
    public static class UserErrors
    {
        public static Error NotFound(string identityId) => new("User.NotFound", "The user with the IDP identifier {identityId} not found", ErrorType.NotFound);
    }
}
