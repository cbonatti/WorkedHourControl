using WorkedHourControl.Application.DTOs.Responses;
using WorkedHourControl.Application.Utils.Extensions;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class UserExtension
    {
        public static UserResponse ToResponse(this User user)
        {
            if (user == null)
                return null;
            return new UserResponse()
            {
                Id = user.Id,
                Name = user.Employee.Name,
                Profile = user.Employee.Profile.ToReponse(),
                Username = user.Username
            };
        }

        public static LoginConfirmedResponse ToLoginResponse(this User user, string token)
        {
            if (user == null)
                return null;
            return new LoginConfirmedResponse()
            {
                Name = user.Employee.Name,
                Profile = user.Employee.Profile.Description(),
                Username = user.Username,
                Token = token
            };
        }
    }
}
