namespace DAL.Entities
{
  public class RSVP
  {
    public Guid Id { get; set; }
    public List<Wedding> weddings { get; set; }
    public List<AppUser> Guests { get; set; }
  }
}
