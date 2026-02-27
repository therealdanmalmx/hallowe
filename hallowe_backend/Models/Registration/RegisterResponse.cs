using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.DTOs
{
    public class RegisterResponse
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public RegisterResponse()
        {

        }

        public RegisterResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
        public RegisterResponse(bool isSuccessful, IEnumerable<string>? errors)
        {
            IsSuccessful = isSuccessful;
            Errors = errors;
    }
    }
}