using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.DTOs.Responses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Get(long id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return null;
            return user.ToResponse();
        }

        public async Task<UserResponse> Add(AddUserRequest request)
        {
            var user = await _userRepository.Get(request.Username);
            if (user != null)
                return null;
            user = new User(request.Username, request.Password, request.Name, request.Profile);
            await _userRepository.Save(user);
            return user.ToResponse();
        }

        public async Task<UserResponse> Update(UpdateUserRequest request)
        {
            var user = await _userRepository.Get(request.Id);
            if (user == null)
                return null;

            user
                .ChangePassword(request.Password)
                .Employee
                    .ChangeName(request.Name)
                    .ChangeProfile(request.Profile);

            await _userRepository.Save(user);
            return user.ToResponse();
        }
    }
}
