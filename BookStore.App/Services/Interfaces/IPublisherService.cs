using BookStore.Core.Entities;

namespace BookStore.App.Services.Interfaces
{
    public interface IPublisherService
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task<ICollection<PublisherEntity>?> GetAsync();
        public Task<ICollection<PublisherEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<PublisherEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name);
        public Task UpdateAsync(Guid id, string name);
    }
}
