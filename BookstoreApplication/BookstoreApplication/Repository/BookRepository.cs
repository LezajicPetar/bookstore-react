using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LeafDbContext _context;

        public BookRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> DeleteAsync(int bookId)
        {
            var existing = await _context.Books.FindAsync(bookId);

            if (existing == null) return null;

            _context.Books.Remove(existing);
            await _context.SaveChangesAsync();

            return existing;
        }
    }
}
