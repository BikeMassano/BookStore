using BookStore.Core.Entities;

namespace BookStore.App.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task<ICollection<CategoryEntity>?> GetAsync();
        public Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<CategoryEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name);
        public Task UpdateAsync(Guid id, string name);
    }
}
