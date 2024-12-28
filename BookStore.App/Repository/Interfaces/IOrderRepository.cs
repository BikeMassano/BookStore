using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface IOrderRepository : IRepositoryBase
    {
        public Task<ICollection<OrderEntity>?> GetAsync();
        public Task<ICollection<OrderEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<OrderEntity>?> GetByIdAsync(Guid orderId);
        public Task AddAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate);
        public Task UpdateAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate);
    }
}
