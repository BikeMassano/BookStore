using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Repository
{
    public interface IBookRepository : IRepositoryBase
    {
        public Task<ICollection<BookEntity>?> GetAsync();
        public Task<ICollection<BookEntity>?> GetByPageAsync(int page, int pageSize);
        public Task<ICollection<BookEntity>?> GetByTitleAsync(string title);
        public Task<ICollection<BookEntity>?> GetByCategoryAsync(Guid categoryId);
        public Task AddAsync(BookEntity bookEntity);
        public Task UpdateAsync(BookEntity bookEntity);
    }
}
