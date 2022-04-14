using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class RSVP
    {
        [Key]
        public Guid RSVPId { get; set; }

    }
}
/* 
USER
Many Weddings and many RSVPS 
Wedding
many Rsvps, One User/creator
RSVP 
one user, one wedding
 */