using System;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.ProjectRequests;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;
using WorkedHourControl.Application.Utils.Extensions;
using WorkedHourControl.Domain.Entities;
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

        public async Task Add(AddWorkedHourRequest request, long emplyeeId)
        {
            var project = await _projectRepository.Get(request.ProjectId);
            project.AddWorkHour(emplyeeId, request.TeamId, request.Date, request.TimeSpent);
            await _projectRepository.Save(project);
        }

        public async Task Update(UpdateWorkedHourRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
