using BookStore.App.Repository.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    class ClientRepository : IClientRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public ClientRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Guid id, string name, string address, string phoneNumber, string email)
        {
            var clientEntity = new ClientEntity
            {
                Id = id,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            await _dbContext.AddAsync(clientEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Clients
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetAsync()
        {
            return await _dbContext.Clients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetByEmailAsync(string email)
        {
            return await _dbContext.Clients
            .AsNoTracking()
                .Where(a => a.Email == email)
                .ToListAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetByNameAsync(string name)
        {
            return await _dbContext.Clients
            .AsNoTracking()
                .Where(a => a.Name == name)
                .ToListAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Clients
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ICollection<ClientEntity>?> GetByPhoneAsync(string phoneNumber)
        {
            return await _dbContext.Clients
            .AsNoTracking()
                .Where(a => a.PhoneNumber == phoneNumber)
                .ToListAsync();
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Clients
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Clients
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task UpdateAsync(Guid id, string name, string address, string phoneNumber, string email)
        {
            await _dbContext.Clients
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Name, name)
                    .SetProperty(c => c.Address, address)
                    .SetProperty(c => c.PhoneNumber, phoneNumber)
                    .SetProperty(c => c.Email, email));
        }
    }
}
