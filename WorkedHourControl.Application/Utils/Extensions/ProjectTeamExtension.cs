using WorkedHourControl.Application.DTOs.Responses.TeamResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class ProjectTeamExtension
    {
        public static TeamSimpleResponse ToTeamResponse(this ProjectTeam projectTeam)
        {
            if (projectTeam == null)
                return null;
            return new TeamSimpleResponse()
            {
                Id = projectTeam.TeamId,
                Name = projectTeam.Team?.Name
            };
        }
    }
}
