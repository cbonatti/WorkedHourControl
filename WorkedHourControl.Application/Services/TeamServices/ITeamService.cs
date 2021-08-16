using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.DTOs.Responses.TeamResponses;

namespace WorkedHourControl.Application.Services.TeamServices
{
    public interface ITeamService
    {
        Task<IList<TeamSimpleResponse>> Get();
        Task<TeamResponse> Get(long id);
        Task<TeamResponse> Add(AddTeamRequest request);
        Task<TeamResponse> Update(UpdateTeamRequest request);
    }
}