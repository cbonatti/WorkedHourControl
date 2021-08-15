using System;
using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;

namespace WorkedHourControl.Application.DTOs.Responses.ProjectResponses
{
    public class WorkedHourDetailResponse
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TimeSpent { get; set; }
        public TeamSimpleResponse Team { get; set; }
        public EmployeeResponse Employee { get; set; }
    }
}
