using BookStore.App.Interfaces.Repository;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public CategoryRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CategoryEntity categoryEntity)
        {
            await _dbContext.AddAsync(categoryEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ICollection<CategoryEntity>?> GetAsync()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<CategoryEntity>?> GetByNameAsync(string name)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Where(a => a.Name == name)
                .ToListAsync();
        }

        public async Task<ICollection<CategoryEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task UpdateAsync(CategoryEntity categoryEntity)
        {
            await _dbContext.Categories
                .Where(a => a.Id == categoryEntity.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, categoryEntity.Name));
        }
    }
}
