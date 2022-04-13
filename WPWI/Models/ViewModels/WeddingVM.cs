using System.ComponentModel.DataAnnotations;

namespace WPWI.Models.ViewModels
{
    public class WeddingVM
    {
        [Required, Display(Name = "Wedding Date: ")]
        public DateTime WeddingDate { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder One: ")]
        public string WedderOne { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder Two: ")]
        public string WedderTwo { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
