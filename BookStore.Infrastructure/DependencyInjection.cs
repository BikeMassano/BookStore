using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Data.Repository.PostgreSQL;
using BookStore.App.Repository.Interfaces;

namespace BookStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("BookStoreDbContext");

            builder.Services.AddDbContext<BookStoreDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                });

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
        }
    }
}
