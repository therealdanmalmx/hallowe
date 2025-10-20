using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.Models
{
    public class TimeSlot
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}