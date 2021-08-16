using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public class ProjectTeamService : IProjectTeamService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectTeamService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IList<TeamSimpleResponse>> GetTeamByProjectAndEmployee(long projectId, long employeeId)
        {
            var project = await _projectRepository.GetWithEmployees(projectId);
            var teams = project.Teams.Where(x => x.Team.Employees.Any(y => y.EmployeeId == employeeId));
            if (teams.Count() == 0)
                return null;
            return teams.Select(x => x.Team.ToSimpleResponse()).ToList();
        }
    }
}
