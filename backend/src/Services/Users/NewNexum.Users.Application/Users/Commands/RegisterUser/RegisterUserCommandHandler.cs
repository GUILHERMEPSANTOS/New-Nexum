using NewNexum.Core.Communication;
using NewNexum.Core.Messaging;
using NewNexum.Infra.IdP;
using NewNexum.Users.Domain.User;

namespace NewNexum.Users.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IIdentityProviderService _identityProviderService, IUserRepository _userRepository) 
        : ICommandHandler<RegisterUserCommand, Result>
    {
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userModel = new UserModel(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName
            );

            Result<string> result = await _identityProviderService
                .RegisterUserAsync(userModel, cancellationToken);

            if(result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var user = User.Create(request.Email, request.FirstName, request.LastName, result.Value);

            _userRepository.Insert(user.Value);

            return Result.Success();
        }
    }
}
