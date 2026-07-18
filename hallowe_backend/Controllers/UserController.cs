using hallowe_backend.DTOs;
using hallowe_backend.Models.Login;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IloginService _loginService;

        public UserController(IRegisterService registerService, IloginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterResponse>>> GetAllParticipants()
        {
            var result = await _registerService.GetAllUsers();
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var result = await _registerService.RegisterUser(request);

            if (!result.IsSuccessful)
            {
                return BadRequest(new RegisterResponse(false, result.Errors));
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var result = await _loginService.Login(request);

            if (!result.IsSuccessful)
            {
                return new LoginResponse(false, result.Errors);
            }

            return Ok(result);
        }
    }
}