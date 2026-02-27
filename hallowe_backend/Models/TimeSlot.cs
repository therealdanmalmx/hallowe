using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.Models
{
    public class TimeSlot
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}