using hallowe_backend.DTOs;
using hallowe_backend.Models;
using hallowe_backend.Models.Login;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IloginService _loginService;
        private readonly SignInManager<User> _signInManager;

        public UserController(IRegisterService registerService, IloginService loginService, SignInManager<User> signInManager)
        {
            _registerService = registerService;
            _loginService = loginService;
            _signInManager = signInManager;
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<RegisterResponse>>> GetAllParticipants()
        {
            var result = await _registerService.GetAllUsers();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult GetCurrentUser()
        {
            return Ok(new
            { 
                id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value,
                userName = User.Identity!.Name,
            });
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
                return Unauthorized(result);
            }

            return Ok(result);
        }
        
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            /* await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme); */
            await _signInManager.SignOutAsync();
            return NoContent();
        }
        
        [HttpGet("google")]
        public IActionResult GoogleLogin() =>
            Challenge(
                new AuthenticationProperties { RedirectUri = "http://localhost:5173/add-address" },
                GoogleDefaults.AuthenticationScheme);

        [HttpGet("facebook")]
        public IActionResult FacebookLogin() =>
            Challenge(
                new AuthenticationProperties { RedirectUri = "http://localhost:5173/add-address" },
                FacebookDefaults.AuthenticationScheme);
    }
}