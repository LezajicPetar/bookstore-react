using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepo.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _authorRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Author", id);
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);

            return await _authorRepo.CreateAsync(author);
        }

        public async Task<Author> UpdateAsync(int id, AuthorDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Author", id);

            _mapper.Map(dto, author);

            return await _authorRepo.UpdateAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _authorRepo.DeleteAsync(id)
                ?? throw new NotFoundException("Author", id);
        }
    }
}
