using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Service
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAsync();
        public Task<Author?> GetByIdAsync(int id);
        public Task<Author> CreateAsync(AuthorDto dto);
        public Task<Author> UpdateAsync(int id, AuthorDto dto);
        public Task DeleteAsync(int id);
    }
}
