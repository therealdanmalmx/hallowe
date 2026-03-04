using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
namespace hallowe_backend.Models
{
    public class User : IdentityUser
    {
        public required string Name { get; set; }

        [JsonIgnore]
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