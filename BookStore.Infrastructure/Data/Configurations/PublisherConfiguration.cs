using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configurations
{
    class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Books)
                .WithOne(a => a.Publisher);
        }
    }
}
