using System.ComponentModel.DataAnnotations;

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

        [MaxLength(350)]
        public string WeddingName
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
