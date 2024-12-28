using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface IPublisherRepository : IRepositoryBase
    {
        public Task<ICollection<PublisherEntity>?> GetAsync();
        public Task<ICollection<PublisherEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<PublisherEntity>?> GetByNameAsync(string name);
        public Task AddAsync(Guid id, string name);
        public Task UpdateAsync(Guid id, string name);
    }
}
