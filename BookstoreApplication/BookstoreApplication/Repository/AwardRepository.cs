using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class AwardRepository
    {
        private readonly LeafDbContext _context;

        public AwardRepository(LeafDbContext context)
        {
            _context = context;
        }

        public List<Award> GetAll()
        {
            return _context.Awards
                .AsNoTracking()
                .ToList();
        }

        public Award? GetById(int id)
        {
            return _context.Awards.Find(id);
        }

        public Award Create(Award award)
        {
            _context.Awards.Add(award);
            _context.SaveChanges();
            return award;
        }

        public Award? Update(Award award)
        {
            var existing = _context.Awards.Find(award.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(award);
            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int awardId)
        {
            var existing = _context.Awards.Find(awardId);

            if (existing == null) return false;

            _context.Awards.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
