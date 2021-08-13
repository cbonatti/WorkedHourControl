using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.DTOs.Responses
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
    }
}
