using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface IAuthorRepository : IRepositoryBase
    {
        public Task<ICollection<AuthorEntity>?> GetAsync();
        public Task<ICollection<AuthorEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<AuthorEntity>?> GetByNameAsync(string name);
        public Task AddAsync(AuthorEntity authorEntity);
        public Task UpdateAsync(AuthorEntity authorEntity);
    }
}
