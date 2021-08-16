using System.Collections.Generic;

namespace WorkedHourControl.Application.DTOs.Responses.ProjectResponses
{
    public class WorkedHourResponse
    {
        public IList<WorkedHourDetailResponse> WorkedHours { get; set; }
    }
}
