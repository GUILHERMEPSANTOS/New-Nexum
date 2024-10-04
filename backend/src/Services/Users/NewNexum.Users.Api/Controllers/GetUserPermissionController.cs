using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;
using NewNexum.Core.Extensions;
using NewNexum.Users.Application.Users.Queries.GetUserPermissions;
using NewNexum.WebApi.Core.Controllers;

namespace NewNexum.Users.Api.Controllers
{

    [Route("users/permissions")]
    public class GetUserPermissionController : ApiControllerBase
    {
        public GetUserPermissionController(IMediator _mediator) : base(_mediator)
        {
        }

        [HttpGet]        
        public async Task<IActionResult> GetUserPermission()
        {
            return await Result.Create(new GetUserPermissionQuery())
                    .Bind(query => _mediator.Send(query))
                    .Match(Ok, BadRequest);
        }
    }
}
