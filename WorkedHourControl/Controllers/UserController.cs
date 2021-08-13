using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.Services.UserServices;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _userService.Add(request);
            if (response == null)
                return Conflict($"Já existe usuáario com o username '{request.Username}'");
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Name))
                return BadRequest("Informe todos os campos obrigatórios");
            var response = await _userService.Update(request);
            if (response == null)
                return NotFound($"Usuário não encontrado");
            return Ok(response);
        }
    }
}
