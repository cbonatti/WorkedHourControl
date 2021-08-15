using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.DTOs.Responses;

namespace WorkedHourControl.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<UserResponse> Get(long id);
        Task<UserResponse> Add(AddUserRequest request);
        Task<UserResponse> Update(UpdateUserRequest request);
    }
}
