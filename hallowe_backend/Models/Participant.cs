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

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string StreetName { get; set; } = string.Empty;
        [Required]
        public string StreetNumber { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public TimeSlot TimeSlots { get; set; }
        public Guid TimeSlotId { get; set; }

    }
}