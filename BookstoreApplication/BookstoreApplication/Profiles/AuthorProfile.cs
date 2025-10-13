using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() 
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
