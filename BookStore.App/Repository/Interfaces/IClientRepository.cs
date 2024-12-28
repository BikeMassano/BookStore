using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface IClientRepository : IRepositoryBase
    {
        public Task<ICollection<ClientEntity>?> GetAsync();
        public Task<ICollection<ClientEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<ClientEntity>?> GetByNameAsync(string name);
        public Task<ICollection<ClientEntity>?> GetByEmailAsync(string email);
        public Task<ICollection<ClientEntity>?> GetByPhoneAsync(string phoneNumber);
        public Task AddAsync(Guid id, string name, string address, string phoneNumber, string email);
        public Task UpdateAsync(Guid id, string name, string address, string phoneNumber, string email);
    }
}
