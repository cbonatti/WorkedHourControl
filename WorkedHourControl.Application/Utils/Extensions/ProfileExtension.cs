using WorkedHourControl.Application.DTOs.Responses.ProfileResponses;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils.Extensions
{
    public static class ProfileExtension
    {
        public static ProfileResponse ToReponse(this Profile profile) => new ProfileResponse(profile);
    }
}
