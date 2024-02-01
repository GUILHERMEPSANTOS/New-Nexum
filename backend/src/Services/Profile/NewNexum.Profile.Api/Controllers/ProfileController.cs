using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;     

namespace NewNexum.Profile.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            return Ok("Sucesso!!");
        }
    }
}
