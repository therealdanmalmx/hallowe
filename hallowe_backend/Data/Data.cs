
using hallowe_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Location> Locations { get; set; }
            public override DbSet<User> Users { get; set; }
            public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithOne(l => l.User)
                .HasForeignKey<Location>(l => l.UserId);

                modelBuilder.Entity<Location>()
                    .Property(l => l.Name)
                    .IsRequired();
        }

    }
}
