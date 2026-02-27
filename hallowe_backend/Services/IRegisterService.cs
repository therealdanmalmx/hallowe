using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.DTOs;
using hallowe_backend.Models;

namespace hallowe_backend.Services
{
    public interface IRegisterService
    {
        Task<RegisterResponse> RegisterUser(RegisterRequest request);
        Task<List<User>> GetAllUsers();
    }
}