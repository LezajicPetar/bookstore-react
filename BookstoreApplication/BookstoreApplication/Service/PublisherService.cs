using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepo;

        public PublisherService(IPublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _publisherRepo.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepo.GetByIdAsync(id);
        }

        public async Task<Publisher> CreateAsync(PublisherDto dto)
        {
            var publisher = new Publisher
            {
                Name = dto.Name,
                Address = dto.Address,
                Website = dto.Website,
            };

            return await _publisherRepo.CreateAsync(publisher);
        }

        public async Task<Publisher> UpdateAsync(int id, PublisherDto dto)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id)
                ?? throw new InvalidOperationException($"Publisher with the ID: {id} not found.");

            publisher.Name = dto.Name;
            publisher.Address = dto.Address;
            publisher.Website = dto.Website;

            return await _publisherRepo.UpdateAsync(publisher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _publisherRepo.DeleteAsync(id);
        }
    }
}
