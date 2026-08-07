using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
namespace hallowe_backend.Models
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        public Location? Location { get; set; }

        public Guid? LocationId { get; set; }

        public User() {}

        public User(
            string email
        )
        {
            Email = email;
            UserName = email;
        }
    }
}