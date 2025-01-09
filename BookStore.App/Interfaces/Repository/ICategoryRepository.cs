using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface ICategoryRepository : IRepositoryBase
    {
        public Task<ICollection<CategoryEntity>?> GetAsync();
        public Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<CategoryEntity>?> GetByNameAsync(string name);
        public Task AddAsync(CategoryEntity categoryEntity);
        public Task UpdateAsync(CategoryEntity categoryEntity);
    }
}
