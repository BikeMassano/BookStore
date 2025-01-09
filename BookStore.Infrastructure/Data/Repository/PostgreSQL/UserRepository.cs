using BookStore.App.Interfaces.Repository;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    class UserRepository : IUserRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public UserRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserEntity userEntity)
        {
            await _dbContext.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Users
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<ICollection<UserEntity>?> GetAsync()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<UserEntity>?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
            .AsNoTracking()
                .Where(a => a.Email == email)
                .ToListAsync();
        }

        public async Task<UserEntity?> GetByNameAsync(string userName)
        {
            return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<ICollection<UserEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ICollection<UserEntity>?> GetByPhoneAsync(string phoneNumber)
        {
            return await _dbContext.Users
            .AsNoTracking()
                .Where(a => a.PhoneNumber == phoneNumber)
                .ToListAsync();
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Users
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Users
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task UpdateAsync(UserEntity userEntity)
        {
            await _dbContext.Users
                .Where(a => a.Id == userEntity.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.UserName, userEntity.UserName)
                    .SetProperty(c => c.PasswordHash, userEntity.PasswordHash)
                    .SetProperty(c => c.Address, userEntity.Address)
                    .SetProperty(c => c.PhoneNumber, userEntity.PhoneNumber)
                    .SetProperty(c => c.Email, userEntity.Email));
        }
    }
}
