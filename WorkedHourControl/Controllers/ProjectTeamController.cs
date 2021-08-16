using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkedHourControl.Application.Services.ProjectServices;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectTeamController : ControllerBase
    {
        private readonly IProjectTeamService _projectTeamService;

        public ProjectTeamController(IProjectTeamService projectTeamService)
        {
            _projectTeamService = projectTeamService;
        }

        [HttpGet, Route("project/{projectId}/employee/{employeeId}")]
        [AuthorizationRoles(Profile.Manager, Profile.Employee)]
        public async Task<IActionResult> GetByEmplyeeAndProject(long projectId, long employeeId)
        {
            var response = await _projectTeamService.GetTeamByProjectAndEmployee(projectId, employeeId);
            if (response == null)
                return NotFound($"Você não está vinculado a uma equipe nesse projeto");
            return Ok(response);
        }
    }
}
