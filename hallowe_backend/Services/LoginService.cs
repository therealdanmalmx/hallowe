using hallowe_backend.Models;
using hallowe_backend.Models.Login;
using Microsoft.AspNetCore.Identity;

namespace hallowe_backend.Services
{
    public class LoginService : IloginService
    {
        private readonly SignInManager<User> _signInManager;

        public LoginService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(
                request.UserName,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
            {
                return new LoginResponse(false, "Email eller lösenord är fel");
            }

            return new LoginResponse(true, null);
        }
    }
}