using BookStore.App.Interfaces.Repository;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public PublisherRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PublisherEntity publisherEntity)
        {
            await _dbContext.AddAsync(publisherEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Publishers
                .Where(a =>  a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ICollection<PublisherEntity>?> GetAsync()
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<PublisherEntity>?> GetByNameAsync(string name)
        {
            return await _dbContext.Publishers
            .AsNoTracking()
                .Where(a => a.Name == name)
                .ToListAsync();
        }

        public async Task<ICollection<PublisherEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Publishers
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Publishers
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task UpdateAsync(PublisherEntity publisherEntity)
        {
            await _dbContext.Publishers
                .Where(a => a.Id == publisherEntity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Name, publisherEntity.Name));
        }
    }
}
