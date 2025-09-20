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

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> UpdateAsync(Author author)
        {
            var existing = await _context.Authors.FindAsync(author.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(author);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int authorId)
        {
            var existing = await _context.Authors.FindAsync(authorId);

            if(existing == null) return false;

            _context.Authors.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
