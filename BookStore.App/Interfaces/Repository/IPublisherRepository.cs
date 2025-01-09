using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface IPublisherRepository : IRepositoryBase
    {
        public Task<ICollection<PublisherEntity>?> GetAsync();
        public Task<ICollection<PublisherEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<PublisherEntity>?> GetByNameAsync(string name);
        public Task AddAsync(PublisherEntity publisherEntity);
        public Task UpdateAsync(PublisherEntity publisherEntity);
    }
}
