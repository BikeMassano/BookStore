using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase
    {
        public Task<ICollection<UserEntity>?> GetAsync();
        public Task<ICollection<UserEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<UserEntity?> GetByNameAsync(string userName);
        public Task<ICollection<UserEntity>?> GetByEmailAsync(string email);
        public Task<ICollection<UserEntity>?> GetByPhoneAsync(string phoneNumber);
        public Task AddAsync(UserEntity userEntity);
        public Task UpdateAsync(UserEntity userEntity);
    }
}
