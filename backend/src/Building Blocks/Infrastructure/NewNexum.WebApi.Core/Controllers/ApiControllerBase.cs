using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;
using NewNexum.Core.Extensions;
using NewNexum.WebApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.WebApi.Core.Controllers
{
    [Authorize]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected new IActionResult Ok(object value) => base.Ok(value);

        protected new IActionResult BadRequest(Error error) => base.BadRequest(new ApiErrorResponse(new[] { error }));

        protected new IActionResult BadRequest(Result result) => base.BadRequest(result.ToProblemDetails());
    }
}
