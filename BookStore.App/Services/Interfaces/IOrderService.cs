using BookStore.Core.Entities;

namespace BookStore.App.Services.Interfaces
{
    public interface IOrderService
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task<ICollection<OrderEntity>?> GetAsync();
        public Task<ICollection<OrderEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<OrderEntity>?> GetByIdAsync(Guid orderId);
        public Task AddAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate);
        public Task UpdateAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate);
    }
}
