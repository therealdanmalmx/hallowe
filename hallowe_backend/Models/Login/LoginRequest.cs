using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.Models.Login
{
    public class LoginRequest
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}