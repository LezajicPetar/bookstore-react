using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class AwardProfile : Profile
    {
        public AwardProfile() 
        {
            CreateMap<Award, AwardDto>().ReverseMap();
        }
    }
}
