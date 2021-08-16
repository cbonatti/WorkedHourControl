using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IList<ProjectSimpleResponse>> Get()
        {
            var projects = await _projectRepository.Get();
            return projects.Select(x => x.ToSimpleResponse()).OrderBy(x => x.Name).ToList();
        }

        public async Task<IList<ProjectResponse>> GetForReport()
        {
            var projects = await _projectRepository.Get();
            return projects.Select(x => x.ToResponse()).OrderBy(x => x.Name).ToList();
        }

        public async Task<ProjectResponse> Get(long id)
        {
            var project = await _projectRepository.Get(id);
            return project.ToResponse();
        }

        public async Task<ProjectResponse> Add(AddProjectRequest request)
        {
            var teams = request.Teams.Select(x => new ProjectTeam(x)).ToList();
            var project = new Project(request.Name, teams);
            await _projectRepository.Save(project);
            return project.ToResponse();
        }

        public async Task<ProjectResponse> Update(UpdateProjectRequest request)
        {
            var project = await _projectRepository.Get(request.Id);
            if (project == null)
                return null;

            project.ChangeName(request.Name);

            var removedTeams = project.Teams.Where(storedTeams => !request.Teams.Any(requestTeams => storedTeams.TeamId == requestTeams)).ToList();
            var addedTeams = request.Teams.Where(requestTeams => !project.Teams.Any(storedTeams => storedTeams.TeamId == requestTeams)).ToList();

            foreach (var teamToRemove in removedTeams)
                project.RemoveTeam(teamToRemove);

            foreach (var teamToAdd in addedTeams)
                project.AddTeam(teamToAdd);

            await _projectRepository.Save(project);
            return project.ToResponse();
        }
    }
}
