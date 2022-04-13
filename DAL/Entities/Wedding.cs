using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Wedding
    {
        [Required, Display(Name = "Wedding Date: ")]
        public DateTime WeddingDate { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder One: ")]
        public string WedderOne { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder Two: ")]
        public string WedderTwo { get; set; }

        public string WeddingName
        {
            get
            {
                return $"Welcome to {WedderOne} and {WedderTwo}'s Wedding";
            }
        }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
