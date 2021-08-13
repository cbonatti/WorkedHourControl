using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;

namespace WorkedHourControl.Application.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeResponse>> Get();
    }
}