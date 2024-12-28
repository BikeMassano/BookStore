using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase
    {
        public Task<ICollection<CategoryEntity>?> GetAsync();
        public Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<CategoryEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name);
        public Task UpdateAsync(Guid id, string name);
    }
}
