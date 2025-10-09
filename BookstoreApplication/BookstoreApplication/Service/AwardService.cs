using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepo;

        public AwardService(IAwardRepository awardRepo)
        {
            _awardRepo = awardRepo;
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            return await _awardRepo.GetAllAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _awardRepo.GetByIdAsync(id);
        }

        public async Task<Award> CreateAsync(AwardDto dto)
        {
            var award = new Award
            {
                Name = dto.Name,
                Description = dto.Description,
                StartYear = dto.StartYear,
            };

            return await _awardRepo.CreateAsync(award);
        }

        public async Task<Award> UpdateAsync(int id, AwardDto dto)
        {
            var award = await _awardRepo.GetByIdAsync(id)
                ?? throw new InvalidOperationException($"Award with the ID: {id} not found.");

            award.Name = dto.Name;
            award.Description = dto.Description;
            award.StartYear = dto.StartYear;

            return await _awardRepo.UpdateAsync(award);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _awardRepo.DeleteAsync(id);
        }
    }
}
