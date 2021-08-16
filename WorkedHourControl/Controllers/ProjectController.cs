using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.Services.ProjectServices;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet, Route("list")]
        [AuthorizationRoles(Profile.Manager, Profile.Employee)]
        public async Task<IActionResult> Get()
        {
            var response = await _projectService.Get();
            return Ok(response);
        }

        [HttpGet, Route("report")]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> GetForReport()
        {
            var response = await _projectService.GetForReport();
            return Ok(response);
        }

        [HttpGet]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> GetById([FromQuery]long id)
        {
            var response = await _projectService.Get(id);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> Post(AddProjectRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _projectService.Add(request);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizationRoles(Profile.Manager)]
        public async Task<IActionResult> Put(UpdateProjectRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _projectService.Update(request);
            if (response == null)
                return NotFound($"Projeto não encontrado");
            return Ok(response);
        }
    }
}
