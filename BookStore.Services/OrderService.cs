using BookStore.App.Repository.Interfaces;
using BookStore.App.Services.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate)
        {
            await _repository.AddAsync(id, bookId, clientId, orderDate);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<OrderEntity>?> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<ICollection<OrderEntity>?> GetByIdAsync(Guid orderId)
        {
            return await _repository.GetByIdAsync(orderId);
        }

        public async Task<ICollection<OrderEntity>?> GetByPageAsync(int page, int pageSize)
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

        public async Task UpdateAsync(Guid id, Guid bookId, Guid clientId, DateTime orderDate)
        {
            await _repository.UpdateAsync(id, bookId, clientId, orderDate);
        }
    }
}
