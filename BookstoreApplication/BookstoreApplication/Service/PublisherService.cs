using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using BookstoreApplication.Service.Interfaces;

namespace BookstoreApplication.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PublisherService> _logger;
        private IUnitOfWork _unitOfWork;

        public PublisherService(
            IPublisherRepository publisherRepo,
            IMapper mapper,
            ILogger<PublisherService> logger,
            IUnitOfWork unitOfWork)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _publisherRepo.GetAllAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _publisherRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Publisher", id);
        }

        public async Task<Publisher> CreateAsync(PublisherDto dto)
        {
            var publisher = _mapper.Map<Publisher>(dto);
            Publisher newPublisher = null;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                newPublisher = await _publisherRepo.CreateAsync(publisher);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return newPublisher;
        }

        public async Task<Publisher> UpdateAsync(int id, PublisherDto dto)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Publisher", id);

            Publisher updatedPublisher = null;

            _mapper.Map(dto, publisher);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                updatedPublisher = await _publisherRepo.UpdateAsync(publisher);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return updatedPublisher;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var deleted = await _publisherRepo.DeleteAsync(id)
                    ?? throw new NotFoundException("Publisher", id);

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
