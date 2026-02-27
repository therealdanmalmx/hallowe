using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace hallowe_backend.Models
{
    public class Participant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; } = string.Empty;
        public required string StreetName { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required TimeSlot TimeSlots { get; set; }
        public Guid TimeSlotId { get; set; }

    }
}