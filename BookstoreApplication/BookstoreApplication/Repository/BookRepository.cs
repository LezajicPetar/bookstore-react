using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class BookRepository
    {
        private readonly LeafDbContext _context;

        public BookRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
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

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            var existing = await _context.Books.FindAsync(bookId);

            if (existing == null) return false;

            _context.Books.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
