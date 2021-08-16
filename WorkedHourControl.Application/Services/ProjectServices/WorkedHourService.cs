using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.ProjectRequests;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;
using WorkedHourControl.Application.Utils.Extensions;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public class WorkedHourService : IWorkedHourService
    {
        private readonly IWorkedHourRepository _workedHourRepository;
        private readonly IProjectRepository _projectRepository;

        public WorkedHourService(IWorkedHourRepository workedHourRepository, IProjectRepository projectRepository)
        {
            _workedHourRepository = workedHourRepository;
            _projectRepository = projectRepository;
        }

        public async Task<WorkedHourResponse> Get(long projectId, long employeeId)
        {
            var workedHours = await _workedHourRepository.GetByEmployee(employeeId, projectId);
            return workedHours.ToResponse();
        }

        public async Task Save(AddWorkedHourRequest request)
        {
            var project = await _projectRepository.Get(request.ProjectId);
            project.AddWorkHour(request.EmployeeId, request.TeamId, request.Date, request.TimeSpent);
            await _projectRepository.Save(project);
        }

        public async Task Delete(long id) => await _workedHourRepository.Delete(id);

        public async Task<WorkedHourResponse> Report(WorkedHourReportRequest request)
        {
            var workedHours = await _workedHourRepository.Report(request.StartDate, request.EndDate, request.ProjectId, request.TeamId, request.EmployeeId);
            return workedHours.ToResponse();
        }
    }
}
