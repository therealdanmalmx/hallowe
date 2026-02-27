using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace hallowe_backend.Models
{
    public class User : IdentityUser
    {
        public required string Name { get; set; }
        public Location? Location { get; set; }

        public User() {}

        public User(
            string name,
            string userName,
            string email,
            string phoneNumber
        )
        {
            Name = name;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}