using BookStore.Core.Entities;

namespace BookStore.App.Repository.Interfaces
{
    public interface IBookRepository : IBaseRepository
    {
        public Task<ICollection<BookEntity>?> GetAsync();
        public Task<ICollection<BookEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<BookEntity>?> GetByTitleAsync(string title);
        public Task<ICollection<BookEntity>?> GetByCategoryAsync(Guid categoryId);
        public Task AddAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId);
        public Task UpdateAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId);
    }
}
