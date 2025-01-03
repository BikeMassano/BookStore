using BookStore.App.Repository.Interfaces;
using BookStore.App.Services.Interfaces;
using BookStore.Core.Entities;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId)
        {
            await _repository.AddAsync(id, title, publishDate, price, authorId, categoryId, publisherId);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<BookEntity>?> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<ICollection<BookEntity>?> GetByCategoryAsync(Guid categoryId)
        {
            return await _repository.GetByCategoryAsync(categoryId);
        }

        public async Task<ICollection<BookEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _repository.GetByPageAsync(page, pageSize);
        }

        public async Task<ICollection<BookEntity>?> GetByTitleAsync(string title)
        {
            return await _repository.GetByTitleAsync(title);
        }

        public async Task RecoverAsync(Guid id)
        {
            await _repository.RecoverAsync(id);
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _repository.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId)
        {
            await _repository.UpdateAsync(id,title, publishDate, price, authorId,categoryId, publisherId);
        }
    }
}
