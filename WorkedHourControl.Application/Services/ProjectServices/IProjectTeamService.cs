using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public interface IProjectTeamService
    {
        Task<IList<TeamSimpleResponse>> GetTeamByProjectAndEmployee(long projectId, long employeeId);
    }
}