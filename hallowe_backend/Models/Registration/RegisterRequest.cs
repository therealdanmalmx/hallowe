using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Models;

namespace hallowe_backend.DTOs
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }
    }
}