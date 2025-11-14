using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LeafDbContext _context;

        public PublisherRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publishers
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<Publisher> CreateAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            return publisher;
        }

        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            return publisher;
        }

        public async Task<Publisher?> DeleteAsync(int publisherId)
        {
            var existing = await _context.Publishers.FindAsync(publisherId);

            if (existing == null) return null;

            _context.Publishers.Remove(existing);

            return existing;
        }
    }
}
