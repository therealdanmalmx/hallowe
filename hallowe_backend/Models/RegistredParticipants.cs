using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace hallowe_backend.Models
{
    public class RegistredParticipants : IdentityUser
    {
        public required string StreetName { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required TimeSlot TimeSlots { get; set; }
        public Guid TimeSlotId { get; set; }

        public RegistredParticipants() {}

        public RegistredParticipants(
            string userName,
            string email,
            string phoneNumber,
            string streetName,
            string streetNumber,
            string city,
            string postalCode,
            decimal latitude,
            decimal longitude,
            TimeSlot timeSlot,
            Guid timeSlotId
        )
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            StreetName = streetName;
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
            Latitude = latitude;
            Longitude = longitude;
            TimeSlots = timeSlot;
            TimeSlotId = timeSlotId;
        }
    }
}