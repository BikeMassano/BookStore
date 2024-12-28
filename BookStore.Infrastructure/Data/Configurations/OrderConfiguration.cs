using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Book)
                .WithMany(a => a.Orders);

            builder.HasOne(a => a.Client)
                .WithMany(a => a.Orders);
        }
    }
}
