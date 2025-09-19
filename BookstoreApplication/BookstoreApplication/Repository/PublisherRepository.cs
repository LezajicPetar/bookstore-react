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

        public List<Publisher> GetAll()
        {
            return _context.Publishers
                .AsNoTracking()
                .ToList();
        }

        public Publisher? GetById(int id)
        {
            return _context.Publishers.Find(id);
        }

        public Publisher Create(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public Publisher? Update(Publisher publisher)
        {
            var existing = _context.Publishers.Find(publisher.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(publisher);
            _context.SaveChanges();

            return existing;
        }

        public bool Delete(int publisherId)
        {
            var existing = _context.Publishers.Find(publisherId);

            if (existing == null) return false;

            _context.Publishers.Remove(existing);
            _context.SaveChanges();

            return true;
        }
    }
}
