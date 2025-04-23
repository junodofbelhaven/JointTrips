using JointTrips.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JointTrips.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trip>()
                .HasMany(t => t.Participants)
                .WithMany(u => u.TripsJoined);


            builder.Entity<Trip>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.TripsOwned)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
