using BookStore.App.Repository.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public AuthorRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<AuthorEntity>?> GetAsync()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<AuthorEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ICollection<AuthorEntity>?> GetByNameAsync(string name)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Where(a => a.Name == name)
                .ToListAsync();
        }

        public async Task AddAsync(Guid id, string name, DateOnly birthDate)
        {
            var authorEntity = new AuthorEntity
            {
                Id = id,
                Name = name,
                BirthDate = birthDate
            };

            await _dbContext.AddAsync(authorEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string name, DateOnly birthDate)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, name)
                    .SetProperty(c => c.BirthDate, birthDate));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
