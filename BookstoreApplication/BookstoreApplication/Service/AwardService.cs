using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using BookstoreApplication.Repository;
using BookstoreApplication.Service.Interfaces;

namespace BookstoreApplication.Service
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AwardService> _logger;
        private IUnitOfWork _unitOfWork;

        public AwardService(
            IAwardRepository awardRepo,
            IMapper mapper, 
            ILogger<AwardService> logger,
            IUnitOfWork unitOfWork)
        {
            _awardRepo = awardRepo;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all awards...");

            var awards = await _awardRepo.GetAllAsync();

            _logger.LogInformation("Fetched {Count} awards.", awards.Count());

            return awards;
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching award with ID {AwardId}", id);

            var award = await _awardRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Award", id);

            _logger.LogInformation("Award with ID {AwardId} retrieved successfully.", id);

            return award;
        }

        public async Task<Award> CreateAsync(AwardDto dto)
        {
            _logger.LogInformation("Creating new award: {AwardName}", dto.Name);

            var award = _mapper.Map<Award>(dto);
            Award created = null;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                created = await _awardRepo.CreateAsync(award);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            _logger.LogInformation("Award created successfully with ID {AwardId}", created.Id);

            return created;
        }

        public async Task<Award> UpdateAsync(int id, AwardDto dto)
        {
            _logger.LogInformation("Updating award with ID {AwardId}.", id);

            var award = await _awardRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Award", id);

            _mapper.Map(dto, award);

            Award updated = null;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                updated = await _awardRepo.UpdateAsync(award);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            _logger.LogInformation("Award with ID {AwardId} successfully updated.", id);

            return updated;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Attempting to delete award with ID {AwardId}", id);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var deleted = await _awardRepo.DeleteAsync(id)
                    ?? throw new NotFoundException("Award", id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            _logger.LogInformation("Award with ID {AwardId} deleted successfully.", id);
        }
    }
}
