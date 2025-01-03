using BookStore.Core.Entities;

namespace BookStore.App.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task<ICollection<AuthorEntity>?> GetAsync();
        public Task<ICollection<AuthorEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<AuthorEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name, DateOnly birthDate);
        public Task UpdateAsync(Guid id, string name, DateOnly birthDate);
    }
}
