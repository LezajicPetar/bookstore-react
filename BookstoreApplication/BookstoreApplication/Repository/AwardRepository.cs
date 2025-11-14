using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class AwardRepository : IAwardRepository
    {
        private readonly LeafDbContext _context;

        public AwardRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            return await _context.Awards
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        public async Task<Award> CreateAsync(Award award)
        {
            await _context.Awards.AddAsync(award);
            return award;
        }

        public async Task<Award> UpdateAsync(Award award)
        {
            _context.Awards.Update(award);
            return award;
        }

        public async Task<Award?> DeleteAsync(int awardId)
        {
            var existing = await _context.Awards.FindAsync(awardId);

            if (existing == null) return null;

            _context.Awards.Remove(existing);

            return existing;
        }
    }
}
