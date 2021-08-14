using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.Services.TeamServices;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [AuthorizationRoles(Profile.Manager, Profile.Employee)]
        public async Task<IActionResult> Get()
        {
            var response = await _teamService.Get();
            return Ok(response);
        }

        [HttpPost]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> Post(AddTeamRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _teamService.Add(request);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> Put(UpdateTeamRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _teamService.Update(request);
            if (response == null)
                return NotFound($"Equipe não encontrada");
            return Ok(response);
        }
    }
}
