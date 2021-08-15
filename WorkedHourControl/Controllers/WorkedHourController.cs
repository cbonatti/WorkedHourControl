using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.ProjectRequests;
using WorkedHourControl.Application.Services.ProjectServices;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkedHourController : ControllerBase
    {
        private readonly IWorkedHourService _workedHourService;

        public WorkedHourController(IWorkedHourService workedHourService)
        {
            _workedHourService = workedHourService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _workedHourService.Add(new AddWorkedHourRequest() { TeamId = 1, ProjectId = 1, Date = DateTime.Now, TimeSpent = 10 }, 1);
            return Ok("baaaata");
        }
    }
}
