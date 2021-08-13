using Microsoft.AspNetCore.Mvc;
using WorkedHourControl.Application.DTOs.Responses.ProfileResponses;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var profiles = ProfileResponse.ListProfiles();
            return Ok(profiles);
        }
    }
}
