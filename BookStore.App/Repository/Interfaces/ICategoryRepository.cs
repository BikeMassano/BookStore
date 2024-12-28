using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface ICategoryRepository : IBaseRepository
    {
        public Task<ICollection<CategoryEntity>?> GetAsync();
        public Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<CategoryEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string title);
        public Task UpdateAsync(Guid id, string title);
    }
}
