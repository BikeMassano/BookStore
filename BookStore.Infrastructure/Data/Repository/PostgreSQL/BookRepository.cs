using BookStore.App.Repository.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.PostgreSQL
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<BookEntity>?> GetAsync()
        {
            return await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<BookEntity>?> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ICollection<BookEntity>?> GetByCategoryAsync(Guid categoryId)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Where(a => a.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<ICollection<BookEntity>?> GetByTitleAsync(string title)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Where(a => a.Title == title)
                .ToListAsync();
        }

        public async Task AddAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId)
        {
            var book = new BookEntity
            {
                Id = id,
                Title = title,
                PublishDate = publishDate,
                Price = price,
                AuthorId = authorId,
                CategoryId = categoryId,
                PublisherId = publisherId
            };

            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string title, DateOnly publishDate, decimal price, Guid authorId, Guid categoryId, Guid publisherId)
        {
            await _dbContext.Books
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, title)
                    .SetProperty(c => c.PublishDate, publishDate)
                    .SetProperty(c => c.Price, price)
                    .SetProperty(c => c.AuthorId, authorId)
                    .SetProperty(c => c.CategoryId, categoryId)
                    .SetProperty(c => c.PublisherId, publisherId));
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            await _dbContext.Books
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, true));
        }

        public async Task RecoverAsync(Guid id)
        {
            await _dbContext.Books
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.IsDeleted, false));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Books
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
