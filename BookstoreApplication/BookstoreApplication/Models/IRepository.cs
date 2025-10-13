namespace BookstoreApplication.Models
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T> UpdateAsync(T entity);
        public Task<T> CreateAsync(T author);
        public Task<T?> DeleteAsync(int id);
    }
}
