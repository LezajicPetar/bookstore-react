using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LeafDbContext _context;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(LeafDbContext context, ILogger<AuthorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            _logger.LogDebug("Querying database for authors...");

            var authors = await _context.Authors
                .AsNoTracking()
                .ToListAsync();

            _logger.LogDebug("Retrieved {Count} authors.", authors.Count);

            return authors;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            _logger.LogDebug("Querying database for author with ID {AuthorId}...", id);

            var author = await _context.Authors.FindAsync(id);

            if (author is null)
                _logger.LogDebug("No Author found for ID {AuthorId}.", id);
            else
                _logger.LogDebug("Author with ID {AuthorId} retrieved successfully.", id);

            return author;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            _logger.LogDebug("Inserting new Author into database: {FullName}...", author.FullName);

            await _context.Authors.AddAsync(author);

            _logger.LogDebug("Autor with ID {AuthorId} succesfully inserted.", author.Id);

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _logger.LogDebug("Updating Author entity in database: ID={AuthorId}...", author.Id);

            _context.Authors.Update(author);

            _logger.LogDebug("Author with ID {AuthorId} successfully updated.", author.Id);

            return author;
        }

        public async Task<Author?> DeleteAsync(int id)
        {
            var existing = await _context.Authors.FindAsync(id);

            if(existing == null) return null;

            _context.Authors.Remove(existing);

            return existing;
        }
    }
}
