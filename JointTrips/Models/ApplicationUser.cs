using Microsoft.AspNetCore.Identity;

namespace JointTrips.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Trip> TripsOwned { get; set; } = new List<Trip>();
        public ICollection<Trip> TripsJoined { get; set; } = new List<Trip>();

    }
}
