using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class PublisherRepository
    {
        private readonly LeafDbContext _context;

        public PublisherRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetAllAsync()
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
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();

            return publisher;
        }

        public async Task<bool> DeleteAsync(int publisherId)
        {
            var existing = await _context.Publishers.FindAsync(publisherId);

            if (existing == null) return false;

            _context.Publishers.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
