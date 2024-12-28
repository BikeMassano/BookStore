using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface IAuthorRepository : IBaseRepository
    {
        public Task<ICollection<AuthorEntity>?> GetAsync();
        public Task<ICollection<AuthorEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<AuthorEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name, DateOnly birthDate);
        public Task UpdateAsync(Guid id, string name, DateOnly birthDate);
    }
}
