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

        public List<Book> GetAll()
        {
            return _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsNoTracking()
                .ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsNoTracking()
                .FirstOrDefault(b => b.Id == id);
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book? Update(Book book)
        {
            var existing = _context.Books.Find(book.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int bookId)
        {
            var existing = _context.Books.Find(bookId);

            if (existing == null) return false;

            _context.Books.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
