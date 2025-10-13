using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile() 
        {
            CreateMap<Publisher, PublisherDto>().ReverseMap();
        }
    }
}
