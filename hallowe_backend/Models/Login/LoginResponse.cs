using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.Models.Login
{
    public class LoginResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Errors { get; set; } = null;
        public string? Token { get; set; } = null;

        public LoginResponse() { }
        public LoginResponse(bool isSuccessful, string? errors)
        {
            IsSuccessful = isSuccessful;
            Errors = errors;
        }
        public LoginResponse(bool isSuccessful, string? errors, string? token)
        {
            IsSuccessful = isSuccessful;
            Errors = errors;
            Token = token;
        }
    }
}