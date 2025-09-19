using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class AuthorRepository
    {
        private readonly LeafDbContext _context;

        public AuthorRepository(LeafDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors
                .AsNoTracking()
                .ToList();
        }

        public Author? GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public Author Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author? Update(Author author)
        {
            var existing = _context.Authors.Find(author.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(author);
            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int authorId)
        {
            var existing = _context.Authors.Find(authorId);

            if(existing == null) return false;

            _context.Authors.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
