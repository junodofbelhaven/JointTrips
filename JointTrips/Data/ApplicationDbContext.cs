using JointTrips.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                .HasOne(t => t.Owner)
                .WithMany(u => u.TripsOwned)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Trip>()
                .HasOne(t => t.SecondaryOwner)
                .WithMany()
                .HasForeignKey(t => t.SecondaryOwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.Entity<Trip>()
                .HasMany(t => t.Participants)
                .WithMany(u => u.TripsJoined)
                .UsingEntity(j => j.ToTable("TripParticipants"));
        }

    }

}
