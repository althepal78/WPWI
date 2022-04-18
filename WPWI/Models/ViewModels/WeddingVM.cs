using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace WPWI.Models.ViewModels
{
    public class WeddingVM
    {
        public Guid WeddingId { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder One: ")]
        public string WedderOne { get; set; }

        [Required, MaxLength(50), Display(Name = "Wedder Two: ")]
        public string WedderTwo { get; set; }

        [Required, Display(Name = "Wedding Date: ")]
        public DateTime WeddingDate { get; set; }

        [Required, Display(Name = "Wedding Address")]
        public string WeddingAddress { get; set; }
              
        public string? WeddingName { get; }

        public AppUser? AppUser { get; set; } 

        public List<RSVP>? RSVP { get; set; }
    }
}
