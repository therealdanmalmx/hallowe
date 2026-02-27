using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Models.Login;

namespace hallowe_backend.Services
{
    public interface IloginService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}