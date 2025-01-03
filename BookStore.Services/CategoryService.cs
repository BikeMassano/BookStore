using BookStore.App.Repository.Interfaces;
using BookStore.App.Services.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, string name)
        {
            await _repository.AddAsync(id, name);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<CategoryEntity>?> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<ICollection<CategoryEntity>?> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _repository.GetByPageAsync(page, pageSize);
        }

        public async Task RecoverAsync(Guid id)
        {
            await _repository.RecoverAsync(id);
        }

        public async Task SoftDeleteAsync(Guid id)
        {
           await _repository.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, string name)
        {
            await _repository.UpdateAsync(id, name);
        }
    }
}
