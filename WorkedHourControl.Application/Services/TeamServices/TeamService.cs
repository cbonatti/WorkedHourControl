using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IList<TeamSimpleResponse>> Get()
        {
            var teams = await _teamRepository.Get();
            return teams.Select(x => x.ToSimpleResponse()).OrderBy(x => x.Name).ToList();
        }

        public async Task<TeamResponse> Get(long id)
        {
            var team = await _teamRepository.Get(id);
            return team.ToResponse();
        }

        public async Task<TeamResponse> Add(AddTeamRequest request)
        {
            var employees = request.Employees.Select(x => new TeamEmployee(x)).ToList();
            var team = new Team(request.Name, employees);
            await _teamRepository.Save(team);
            return team.ToResponse();
        }

        public async Task<TeamResponse> Update(UpdateTeamRequest request)
        {
            var team = await _teamRepository.Get(request.Id);
            if (team == null)
                return null;

            team.ChangeName(request.Name);

            var removedEmployees = team.Employees.Where(storedEmployees => !request.Employees.Any(requestEmployees => storedEmployees.EmployeeId == requestEmployees)).ToList();
            var addedEmployees = request.Employees.Where(requestEmployees => !team.Employees.Any(storedEmployees => storedEmployees.EmployeeId == requestEmployees)).ToList();

            foreach (var employeeToRemove in removedEmployees)
                team.RemoveEmployee(employeeToRemove);

            foreach (var employeeToAdd in addedEmployees)
                team.AddEmployee(employeeToAdd);

            await _teamRepository.Save(team);
            return team.ToResponse();
        }
    }
}
