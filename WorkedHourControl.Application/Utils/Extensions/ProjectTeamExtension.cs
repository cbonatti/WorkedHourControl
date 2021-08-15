using WorkedHourControl.Application.DTOs.Responses.TeamResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class ProjectTeamExtension
    {
        public static TeamResponse ToTeamResponse(this ProjectTeam projectTeam)
        {
            if (projectTeam == null)
                return null;
            return new TeamResponse()
            {
                Id = projectTeam.TeamId,
                Name = projectTeam.Team?.Name
            };
        }
    }
}
