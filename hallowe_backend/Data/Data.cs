
using hallowe_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Participant> Participants { get; set; }
            public DbSet<TimeSlot> TimeSlots { get; set; }
    }
}
