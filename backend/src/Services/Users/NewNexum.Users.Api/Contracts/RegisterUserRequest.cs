using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewNexum.Users.Api.Contracts
{
    public record RegisterUserRequest(
        string Email,
        string Password,
        string FirstName,
        string LastName
     );
}
