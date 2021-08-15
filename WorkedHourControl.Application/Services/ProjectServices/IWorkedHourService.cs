using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.ProjectRequests;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public interface IWorkedHourService
    {
        Task<WorkedHourResponse> Get(long projectId, long employeeId);
        Task Add(AddWorkedHourRequest request, long emplyeeId);
        Task Update(UpdateWorkedHourRequest request);
    }
}