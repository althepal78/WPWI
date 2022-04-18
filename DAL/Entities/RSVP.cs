using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class RSVP
    {
        [Key]
        public Guid RSVPId { get; set; }

        [ForeignKey("WeddingId")]
        public Guid? WeddingID { get; set; }

        [ForeignKey("AppUserId")]
        public string? AppUserId { get; set; }

        public Wedding? wedding { get; set; }

        public AppUser? appUser { get; set; }

    }
}
