using BookStore.App.Interfaces.Repository;
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

        public async Task AddAsync(BookEntity bookEntity)
        {
            await _dbContext.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookEntity bookEntity)
        {
            await _dbContext.Books
                .Where(a => a.Id == bookEntity.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, bookEntity.Title)
                    .SetProperty(c => c.PublishDate, bookEntity.PublishDate)
                    .SetProperty(c => c.Price, bookEntity.Price)
                    .SetProperty(c => c.AuthorId, bookEntity.AuthorId)
                    .SetProperty(c => c.CategoryId, bookEntity.CategoryId)
                    .SetProperty(c => c.PublisherId, bookEntity.PublisherId));
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
