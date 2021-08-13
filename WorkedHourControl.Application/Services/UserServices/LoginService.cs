using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.DTOs.Responses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Repositories;
using WorkedHourControl.Infra.Authorization;

namespace WorkedHourControl.Application.Services.UserServices
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginConfirmedResponse> Login(LoginRequest request)
        {
            // TODO: Implement password encryption
            var user = await _userRepository.Login(request.Username, request.Password);
            if (user == null)
                return null;
            var token = _tokenService.GenerateToken(user.Username, user.Employee.Profile.Description());
            return user.ToLoginResponse(token);
        }
    }
}
