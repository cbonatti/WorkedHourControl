using System.Linq;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class ProjectExtension
    {
        public static ProjectResponse ToResponse(this Project project)
        {
            if (project == null)
                return null;
            return new ProjectResponse()
            {
                Id = project.Id,
                Name = project.Name,
                Teams = project.Teams.Select(x => x.ToTeamResponse()).OrderBy(x => x.Name).ToList()
            };
        }

        public static ProjectSimpleResponse ToSimpleResponse(this Project project)
        {
            if (project == null)
                return null;
            return new ProjectSimpleResponse()
            {
                Id = project.Id,
                Name = project.Name
            };
        }
    }
}
