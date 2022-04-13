using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class RSVP
    {
        [Key]
        public Guid RSVPId { get; set; }
        public List<Wedding> weddings { get; set; }
        public List<AppUser> Guests { get; set; }
    }
}
