using WorkedHourControl.Application.DTOs.Responses.ProfileResponses;

namespace WorkedHourControl.Application.DTOs.Responses
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public ProfileResponse Profile { get; set; }
    }
}
