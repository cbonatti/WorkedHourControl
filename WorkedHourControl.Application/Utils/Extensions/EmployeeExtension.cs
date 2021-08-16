using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;
using WorkedHourControl.Application.Utils.Extensions;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Application.Utils
{
    public static class EmployeeExtension
    {
        public static EmployeeResponse ToResponse(this Employee employee)
        {
            if (employee == null)
                return null;
            return new EmployeeResponse()
            {
                Id = employee.Id,
                Name = employee.Name,
                Profile = employee.Profile.ToReponse()
            };
        }
    }
}
