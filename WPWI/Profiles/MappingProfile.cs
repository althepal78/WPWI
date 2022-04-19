using AutoMapper;
using DAL.Entities;
using WPWI.Models.ViewModels;

namespace WPWI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wedding, WeddingVM>().ForMember(x => x.RSVP, x => x.MapFrom(src => src.RSVPs)).ReverseMap();
            CreateMap<AppUser, AppUserVM>().ReverseMap();
        }
    }
}
