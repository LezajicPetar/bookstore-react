using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepo;
        private readonly IMapper _mapper;

        public AwardService(IAwardRepository awardRepo, IMapper mapper)
        {
            _awardRepo = awardRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            return await _awardRepo.GetAllAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _awardRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Award", id);
        }

        public async Task<Award> CreateAsync(AwardDto dto)
        {
            var award = _mapper.Map<Award>(dto);

            return await _awardRepo.CreateAsync(award);
        }

        public async Task<Award> UpdateAsync(int id, AwardDto dto)
        {
            var award = await _awardRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Award", id);

            _mapper.Map(dto, award);

            return await _awardRepo.UpdateAsync(award);
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _awardRepo.DeleteAsync(id)
                ?? throw new NotFoundException("Award", id);
        }
    }
}
