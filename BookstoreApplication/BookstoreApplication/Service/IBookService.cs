using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Models;

namespace BookstoreApplication.Service
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllAsync();
        public Task<BookDetailsDto?> GetByIdAsync(int id);
        public Task<Book> CreateAsync(BookCreateDto dto);
        public Task<Book> UpdateAsync(int id, BookUpdateDto dto);
        public Task DeleteAsync(int id);

    }
}
