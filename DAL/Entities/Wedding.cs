
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    
    public class Wedding
    {
        [Key]
        public Guid WeddingId { get; set; }

        [Required, Display(Name = "Wedding Date: ")]
        public DateTime WeddingDate { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder One: ")]
        public string WedderOne { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder Two: ")]
        public string WedderTwo { get; set; }

        [Required, MaxLength(1150), Display(Name = "Wedder Two: ")]
        public string WeddingAddress { get; set; }

        [ForeignKey("AppUserId")]
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [MaxLength(350)]
        [NotMapped]
        public string? WeddingName
        {
            get
            {
                return $"Welcome to {WedderOne} and {WedderTwo}'s Wedding";
            }
        }
        public List<RSVP> RSVPs { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
