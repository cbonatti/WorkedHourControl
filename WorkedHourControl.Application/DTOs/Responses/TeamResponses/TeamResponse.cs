using System.Collections.Generic;
using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;

namespace WorkedHourControl.Application.DTOs.Responses.TeamResponses
{
    public class TeamResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<EmployeeResponse> Employees { get; set; }
    }
}
