

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;
using NewNexum.Profile.Api.Contracts;
using NewNexum.Profile.Application.Certification.Commands.CreateCertification;
using NewNexum.WebApi.Core.Controllers;
using API.Extensions;

namespace NewNexum.Profile.Api.Controllers
{
    [Route("profile/certification")]
    [ApiController]
    public class CertificationController : ApiControllerBase
    {
        public CertificationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCertification(RegisterCertificationRequest request)
            => await Result.Create(request)
                    .Map(request => new CreateCertificationCommand(request.Name
                           , request.IssuingOrganization
                           , request.DateOfIssue
                           , request.ExpirationDate
                           , request.CredentialCode
                           , request.CredentialURL))
                    .Bind(command => _mediator.Send(command))
                    .Match(Ok, BadRequest);
    }
}
