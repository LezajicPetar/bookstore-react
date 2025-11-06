using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<RegistrationDto, ApplicationUser>();

            CreateMap<ProfileDto, ApplicationUser>().ReverseMap();
        }
    }
}
