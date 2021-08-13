using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Authorize(Roles = "gestor")]
        public IActionResult Get()
        {
            return Ok("equipes");
        }
    }
}
