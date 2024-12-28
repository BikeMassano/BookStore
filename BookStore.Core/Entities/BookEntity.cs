namespace BookStore.Core.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; } = null!;
        public DateOnly PublishDate { get; set; }
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorEntity? Author { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public Guid PublisherId { get; set; }
        public PublisherEntity? Publisher { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
