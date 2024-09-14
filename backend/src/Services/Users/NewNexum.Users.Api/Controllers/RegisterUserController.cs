using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;
using NewNexum.Core.Extensions;
using NewNexum.Users.Api.Contracts;
using NewNexum.Users.Application.Users.Commands.RegisterUser;
using NewNexum.WebApi.Core.Controllers;

namespace NewNexum.Users.Api.Controllers
{
    [Route("users")]
    public class RegisterUserController : ApiControllerBase
    {
        public RegisterUserController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
            => await Result.Create(request)
               .Map(req =>
                    new RegisterUserCommand(
                        req.Email,
                        req.Password,
                        req.FirstName,
                        req.LastName))
               .Bind(command => _mediator.Send(command))
               .Match(Ok, BadRequest);
    }
}
