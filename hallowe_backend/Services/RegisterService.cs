using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.DTOs;
using hallowe_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.Services
{
    public class RegisterService : IRegisterService
    {

    private readonly UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllUsers()
        {
            if (_userManager.Users == null)
            {
                return [];
            }
            return await _userManager.Users.ToListAsync();
        }

        public async Task<RegisterResponse> RegisterUser(RegisterRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return new RegisterResponse(false, errors);
            }

            return new RegisterResponse(true);
        }
    }
}