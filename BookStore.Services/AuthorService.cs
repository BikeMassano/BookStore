using BookStore.App.Repository.Interfaces;
using BookStore.App.Services.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, string name, DateOnly birthDate)
        {
            await _repository.AddAsync(id, name, birthDate);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<AuthorEntity>?> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<ICollection<AuthorEntity>?> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<ICollection<AuthorEntity>?> GetByPageAsync(int page, int pageSize)
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

        public async Task UpdateAsync(Guid id, string name, DateOnly birthDate)
        {
            await _repository.UpdateAsync(id, name, birthDate);
        }
    }
}
