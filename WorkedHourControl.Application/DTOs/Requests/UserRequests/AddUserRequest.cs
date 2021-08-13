using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.DTOs.Requests
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
    }
}
