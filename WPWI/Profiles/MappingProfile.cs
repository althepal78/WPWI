using AutoMapper;
using DAL.Entities;
using WPWI.Models.ViewModels;

namespace WPWI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wedding, WeddingVM>().ReverseMap();
            CreateMap<AppUser, AppUserVM>().ReverseMap();
        }
    }
}
