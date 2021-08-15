using System.Collections.Generic;

namespace WorkedHourControl.Application.DTOs.Responses.ProjectResponses
{
    public class WorkedHourResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<WorkedHourDetailResponse> WorkedHours { get; set; }
    }
}
