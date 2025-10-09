using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Service
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllAsync();
        public Task<Book?> GetByIdAsync(int id);
        public Task<Book> CreateAsync(BookCreateDto dto);
        public Task<Book> UpdateAsync(int id, BookUpdateDto dto);
        public Task<bool> DeleteAsync(int id);

    }
}
