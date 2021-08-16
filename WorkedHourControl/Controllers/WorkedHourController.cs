using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet, Route("project/{projectId}/employee/{employeeId}")]
        public async Task<IActionResult> Get(long projectId, long employeeId)
        {
            var response = await _workedHourService.Get(projectId, employeeId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddWorkedHourRequest request)
        {
            if (request == null || request.TimeSpent <= 0 || request.TeamId == 0 || request.ProjectId == 0 || request.EmployeeId == 0)
                return BadRequest("Informe todos os campos obrigatórios");
            await _workedHourService.Save(request);
            return Ok();
        }

        [HttpPost, Route("report")]
        public async Task<IActionResult> Post(WorkedHourReportRequest request)
        {
            if (request == null || request.StartDate == DateTime.MinValue || request.EndDate == DateTime.MinValue || request.ProjectId == 0)
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _workedHourService.Report(request);
            return Ok(response);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _workedHourService.Delete(id);
            return Ok();
        }
    }
}
