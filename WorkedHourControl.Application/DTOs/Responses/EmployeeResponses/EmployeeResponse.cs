using WorkedHourControl.Application.DTOs.Responses.ProfileResponses;

namespace WorkedHourControl.Application.DTOs.Responses.EmployeeResponses
{
    public class EmployeeResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ProfileResponse Profile { get; set; }
    }
}
