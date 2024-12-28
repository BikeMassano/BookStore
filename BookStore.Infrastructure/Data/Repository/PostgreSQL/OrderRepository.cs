using BookStore.App.Repository.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public OrderRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate)
        {
            var orderEntity = new OrderEntity
            {
                Id = id,
                BookId = bookId,
                ClientId = clientId,
                Created = orderDate
            };

            await _dbContext.AddAsync(orderEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ICollection<OrderEntity>?> GetAsync()
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<OrderEntity>?> GetByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders
            .AsNoTracking()
                .Where(a => a.Id == orderId)
                .ToListAsync();
        }

        public async Task<ICollection<OrderEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task UpdateAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate)
        {
            await _dbContext.Orders
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.BookId, bookId)
                .SetProperty(c => c.ClientId, clientId)
                .SetProperty(c => c.Created, orderDate));
        }
    }
}
