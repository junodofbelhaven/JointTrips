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

            // Trip ↔ Participants
            builder.Entity<Trip>()
                .HasMany(t => t.Participants)
                .WithMany(u => u.TripsJoined)
                .UsingEntity<Dictionary<string, object>>(
                    "TripParticipants",
                    j => j
                        .HasOne<ApplicationUser>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_TripParticipants_Users_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Trip>()
                        .WithMany()
                        .HasForeignKey("TripId")
                        .HasConstraintName("FK_TripParticipants_Trips_TripId")
                        .OnDelete(DeleteBehavior.Cascade));


            // Trip → Owner
            builder.Entity<Trip>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.TripsOwned)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
