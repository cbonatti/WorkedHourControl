using System.Linq;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class TeamExtension
    {
        public static TeamResponse ToResponse(this Team team)
        {
            if (team == null)
                return null;
            return new TeamResponse()
            {
                Id = team.Id,
                Name = team.Name,
                Employees = team.Employees.Select(x => x.Employee.ToResponse()).ToList()
            };
        }

        public static TeamSimpleResponse ToSimpleResponse(this Team team)
        {
            if (team == null)
                return null;
            return new TeamSimpleResponse()
            {
                Id = team.Id,
                Name = team.Name
            };
        }
    }
}
