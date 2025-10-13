using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepo, IMapper mapper)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _publisherRepo.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Publisher" ,id);
        }

        public async Task<Publisher> CreateAsync(PublisherDto dto)
        {
            var publisher = _mapper.Map<Publisher>(dto);

            return await _publisherRepo.CreateAsync(publisher);
        }

        public async Task<Publisher> UpdateAsync(int id, PublisherDto dto)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Publisher", id);

            _mapper.Map(dto, publisher);

            return await _publisherRepo.UpdateAsync(publisher);
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _publisherRepo.DeleteAsync(id)
                ?? throw new NotFoundException("Publisher", id);
        }
    }
}
