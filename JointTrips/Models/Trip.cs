using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public string? SecondaryOwnerId { get; set; }
        public ApplicationUser? SecondaryOwner { get; set; }

        public ICollection<ApplicationUser> Participants { get; set; } = new List<ApplicationUser>();


    }

}
