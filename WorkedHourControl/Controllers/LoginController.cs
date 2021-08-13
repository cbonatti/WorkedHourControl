using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.Services.UserServices;

namespace WorkedHourControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Informe o usuário e senha");
            var response = await _loginService.Login(request);
            if (response == null)
                return NotFound("Usuário ou senha inválidos");
            return Ok(response);
        }
    }
}
