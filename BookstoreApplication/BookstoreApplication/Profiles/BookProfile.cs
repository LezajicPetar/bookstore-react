using AutoMapper;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Models;

namespace BookstoreApplication.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(
                dest => dest.AuthorFullName,
                opt => opt.MapFrom(src => src.Author.FullName)
                )
                .ForMember(
                dest => dest.PublisherName,
                opt => opt.MapFrom(src => src.Publisher.Name)
                )
                .ForMember(
                dest => dest.AgeInYears,
                opt => opt.MapFrom(src => DateTime.Now.Year - src.PublishedDate.Year)
                );

            CreateMap<Book, BookDetailsDto>()
                .ForMember(
                dest => dest.AuthorFullName,
                opt => opt.MapFrom(src => src.Author.FullName)
                )
                .ForMember(
                dest => dest.PublisherName,
                opt => opt.MapFrom(src => src.Publisher.Name)
                );
        }
    }
}
