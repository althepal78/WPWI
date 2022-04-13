using Microsoft.AspNetCore.Identity;


namespace DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Wedding> Weddings { get; set; }

        public List<RSVP> RSVPs { get; set; }
    }
}
