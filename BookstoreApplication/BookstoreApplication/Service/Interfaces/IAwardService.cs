using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Service.Interfaces
{
    public interface IAwardService
    {
        public Task<IEnumerable<Award>> GetAllAsync();
        public Task<Award?> GetByIdAsync(int id);
        public Task<Award> CreateAsync(AwardDto dto);
        public Task<Award> UpdateAsync(int id, AwardDto dto);
        public Task DeleteAsync(int id);

    }
}
