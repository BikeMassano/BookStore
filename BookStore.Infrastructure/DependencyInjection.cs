using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("BookStoreDbContext");

            // Пример использования полученной строки подключения
            builder.Services.AddDbContext<BookStoreDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                });
        }
    }
}
