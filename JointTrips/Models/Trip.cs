using System.ComponentModel.DataAnnotations;

namespace JointTrips.Models
{
    public class Trip
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; } = "";

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }

        // (ID foreign key)
        public string OwnerId { get; set; }

        // (navigation property)
        public ApplicationUser? Owner { get; set; }

        public ICollection<ApplicationUser> Participants { get; set; } = new List<ApplicationUser>();
    }

}
