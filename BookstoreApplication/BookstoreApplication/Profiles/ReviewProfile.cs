using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
