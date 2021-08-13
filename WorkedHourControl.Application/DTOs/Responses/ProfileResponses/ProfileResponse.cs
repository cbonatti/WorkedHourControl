using System.Collections.Generic;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.DTOs.Responses.ProfileResponses
{
    public class ProfileResponse
    {
        public ProfileResponse(Profile profile)
        {
            Id = (int)profile;
            Name = profile.Description();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static IList<ProfileResponse> ListProfiles()
            => new List<ProfileResponse>() {
                new ProfileResponse(Profile.Employee),
                new ProfileResponse(Profile.Manager)
            };
    }
}
