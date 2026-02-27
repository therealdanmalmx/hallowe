using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.Models;

namespace hallowe_backend.DTOs
{
    public class RegisteredParticipantRequest
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required TimeSlot TimeSlots { get; set; }
        public Guid TimeSlotId { get; set; }
    }
}