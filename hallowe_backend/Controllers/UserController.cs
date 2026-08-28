using System.Security.Claims;
using hallowe_backend.DTOs;
using hallowe_backend.Models;
using hallowe_backend.Models.Login;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Twitter;
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
        private readonly UserManager<User> _userManager;

        public UserController(
            IRegisterService registerService,
            IloginService loginService,
            SignInManager<User> signInManager,
            UserManager<User> userManager
        )
        {
            _registerService = registerService;
            _loginService = loginService;
            _signInManager = signInManager;
            _userManager = userManager;
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
                id = User.FindFirstValue(ClaimTypes.NameIdentifier),
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
            await _signInManager.SignOutAsync();
            return NoContent();
        }

        [HttpGet("google")]
        public IActionResult GoogleLogin()
        {
            var props = _signInManager.ConfigureExternalAuthenticationProperties(
                GoogleDefaults.AuthenticationScheme,
                Url.Action(nameof(ExternalCallback))!);   // → /api/user/external-callback
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("facebook")]
        public IActionResult FacebookLogin()
        {
            var props = _signInManager.ConfigureExternalAuthenticationProperties(
                FacebookDefaults.AuthenticationScheme,
                Url.Action(nameof(ExternalCallback))!);
            return Challenge(props, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("twitter")]
        public IActionResult TwitterLogin()
        {
            var props = _signInManager.ConfigureExternalAuthenticationProperties(
                TwitterDefaults.AuthenticationScheme,
                Url.Action(nameof(ExternalCallback))!);
            return Challenge(props, TwitterDefaults.AuthenticationScheme);
        }

        [HttpGet("external-callback")]
        public async Task<IActionResult> ExternalCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info is null)
                return Redirect("http://localhost:5173/login?error=external");

            // Existing linked account?
            var result = await _signInManager.ExternalLoginSignInAsync(
                info.LoginProvider, info.ProviderKey, isPersistent: true, bypassTwoFactor: true);

            if (!result.Succeeded)
            {
                // First time — create the user and link the login
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrWhiteSpace(email)) email = null;

                var user = email is null ? null : await _userManager.FindByEmailAsync(email);

                if (user is null)
                {
                    user = new User
                    {
                        UserName = email ?? $"{info.LoginProvider}-{info.ProviderKey}",
                        Email = email,
                        EmailConfirmed = email is not null,
                    };
                    var created = await _userManager.CreateAsync(user);
                    if (!created.Succeeded)
                    {
                        var msg = string.Join(" | ", created.Errors.Select(e => e.Code + ": " + e.Description));
                        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                        return Redirect($"http://localhost:5173/login?error=create&detail={Uri.EscapeDataString(msg)}");
                    }
                }

                var linked = await _userManager.AddLoginAsync(user, info);
                if (!linked.Succeeded)
                {
                    var msg = string.Join(" | ", linked.Errors.Select(e => e.Code + ": " + e.Description));
                    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                    return Redirect($"http://localhost:5173/login?error=link&detail={Uri.EscapeDataString(msg)}");
                }

                await _signInManager.SignInAsync(user, isPersistent: true);

            }

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Redirect("http://localhost:5173/add-address");
        }
    }
}