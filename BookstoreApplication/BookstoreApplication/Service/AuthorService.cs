using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepo.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _authorRepo.GetByIdAsync(id);
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            var author = new Author
            {
                FullName = dto.FullName,
                Biography = dto.Biography,
                DateOfBirth = dto.DateOfBirth,
            };

            return await _authorRepo.CreateAsync(author);
        }

        public async Task<Author> UpdateAsync(int id, AuthorDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(id)
                ?? throw new InvalidOperationException($"Author with the ID: {id} not found.");

            author.FullName = dto.FullName;
            author.Biography = dto.Biography;
            author.DateOfBirth = dto.DateOfBirth;

            return await _authorRepo.UpdateAsync(author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _authorRepo.DeleteAsync(id);
        }
    }
}
