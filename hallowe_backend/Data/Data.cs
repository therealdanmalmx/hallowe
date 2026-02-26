
using hallowe_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<RegistredParticipants>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Participant> Participants { get; set; }
            public DbSet<RegistredParticipants> RegistredParticipants { get; set; }
            public DbSet<TimeSlot> TimeSlots { get; set; }
    }
}
