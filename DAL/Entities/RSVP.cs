namespace DAL.Entities
{
    public class RSVP
    {
        public List<Wedding> weddings { get; set; }
        public List<AppUser> Guests { get; set; }
    }
}
