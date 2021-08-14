using System.Collections.Generic;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;

namespace WorkedHourControl.Application.DTOs.Responses.ProjectResponses
{
    public class ProjectResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<TeamResponse> Teams { get; set; }
    }
}
