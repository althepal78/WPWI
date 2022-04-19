using DAL.Entities;

namespace WPWI.Models.ViewModels
{
  public class RSVPVM
  {
    public Guid RSVPId { get; set; }

    public Guid? WeddingID { get; set; }

    public string? AppUserId { get; set; }

    public Wedding? wedding { get; set; }

    public AppUser? appUser { get; set; }
  }
}
