using System;

namespace WorkedHourControl.Application.DTOs.Requests.ProjectRequests
{
    public class WorkedHourReportRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ProjectId { get; set; }
        public long TeamId { get; set; }
        public long EmployeeId { get; set; }
    }
}
