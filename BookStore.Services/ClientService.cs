using BookStore.App.Repository.Interfaces;
using BookStore.App.Services.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, string name, string address, string phoneNumber, string email)
        {
            await _repository.AddAsync(id, name, address, phoneNumber, email);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<ClientEntity>?> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public async Task<ICollection<ClientEntity>?> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<ICollection<ClientEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _repository.GetByPageAsync(page, pageSize);
        }

        public async Task<ICollection<ClientEntity>?> GetByPhoneAsync(string phoneNumber)
        {
            return await _repository.GetByPhoneAsync(phoneNumber);
        }

        public async Task RecoverAsync(Guid id)
        {
            await _repository.RecoverAsync(id);
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _repository.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, string name, string address, string phoneNumber, string email)
        {
            await _repository.UpdateAsync(id, name, address, phoneNumber, email);
        }
    }
}
