using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Service
{
    public interface IPublisherService
    {
        public Task<IEnumerable<Publisher>> GetAllAsync();
        public Task<Publisher?> GetByIdAsync(int id);
        public Task<Publisher> CreateAsync(PublisherDto dto);
        public Task<Publisher> UpdateAsync(int id, PublisherDto dto);
        public Task<bool> DeleteAsync(int id);

    }
}
