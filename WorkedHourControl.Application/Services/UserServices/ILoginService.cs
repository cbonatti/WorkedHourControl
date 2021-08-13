using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.DTOs.Responses;

namespace WorkedHourControl.Application.Services.UserServices
{
    public interface ILoginService
    {
        Task<LoginConfirmedResponse> Login(LoginRequest request);
    }
}
