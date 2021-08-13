using Microsoft.AspNetCore.Mvc;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        public TeamController()
        {

        }

        [HttpGet]
        [AuthorizationRoles(Profile.Manager)]
        public IActionResult Get()
        {
            return Ok("equipes");
        }
    }
}
