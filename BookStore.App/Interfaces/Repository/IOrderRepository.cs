using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface IOrderRepository : IRepositoryBase
    {
        public Task<ICollection<OrderEntity>?> GetAsync();
        public Task<ICollection<OrderEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<OrderEntity?> GetByIdAsync(Guid orderId);
        public Task AddAsync(OrderEntity orderEntity);
        public Task UpdateAsync(OrderEntity orderEntity);
    }
}
