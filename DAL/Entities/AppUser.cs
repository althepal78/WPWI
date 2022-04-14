using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public List<Wedding> Weddings { get; set; }

        public List<RSVP> RSVPs { get; set; }
    }
}
