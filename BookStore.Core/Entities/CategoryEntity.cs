namespace BookStore.Core.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<BookEntity>? Books { get; set; } = [];
    }
}
