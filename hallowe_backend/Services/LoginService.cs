using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using hallowe_backend.Models;
using hallowe_backend.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace hallowe_backend.Services
{
    public class LoginService : IloginService
    {
        private readonly SignInManager<User> _registerSignInManager;
        private readonly IConfiguration _config;

        public LoginService(SignInManager<User> registeredParticipantSignInManager, IConfiguration config)
        {
            _registerSignInManager = registeredParticipantSignInManager;
            _config = config;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var result = await _registerSignInManager.PasswordSignInAsync(
                request.UserName,
                request.Password,
                false,
                false
            );

            if (!result.Succeeded)
            {
                return new LoginResponse(false, "Email eller lösenord är fel");
            }

            var claims = new []
            {
                new Claim(ClaimTypes.Name, request.UserName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JwtsecurityKey"]!)
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.UtcNow.AddDays(Convert.ToInt16(_config["JwtExpiryDate"]));
            var token = new JwtSecurityToken(
                issuer: _config["JwtIssuer"],
                audience: _config["JwtAudience"],
                claims: claims,
                expires: expiryDate,
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponse(true, null, jwt);
        }
    }
}