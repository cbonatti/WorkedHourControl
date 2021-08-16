using System.Collections.Generic;
using System.Linq;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils.Extensions
{
    public static class WorkedHourExtension
    {
        public static WorkedHourResponse ToResponse(this IList<ProjectWorkedHour> workedHour)
        {
            if (workedHour == null)
                return null;

            var response = new WorkedHourResponse();

            if (workedHour.Count == 0)
                return response;
            response.WorkedHours = workedHour.Select(x => new WorkedHourDetailResponse()
            {
                Id = x.Id,
                Date = x.Date,
                TimeSpent = x.TimeSpent,
                //Employee = x.Employee.ToResponse(),
                Team = x.Team.ToSimpleResponse()
            }).ToList();
            return response;
        }
    }
}
