using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;

namespace NewNexum.Users.Application.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string Email,
        string Password,
        string FirstName,
        string LastName
     ) : ICommand;
}
