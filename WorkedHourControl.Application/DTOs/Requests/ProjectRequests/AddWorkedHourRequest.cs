using System;

namespace WorkedHourControl.Application.DTOs.Requests.ProjectRequests
{
    public class AddWorkedHourRequest
    {
        public DateTime Date { get; set; }
        public decimal TimeSpent { get; set; }
        public long ProjectId { get; set; }
        public long TeamId { get; set; }
        public long EmployeeId { get; set; }
    }
}
