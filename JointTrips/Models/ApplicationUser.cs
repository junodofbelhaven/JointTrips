using Microsoft.AspNetCore.Identity;

namespace JointTrips.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Trip> TripsOwned { get; set; }
        public ICollection<Trip> TripsJoined { get; set; }
    }
}
