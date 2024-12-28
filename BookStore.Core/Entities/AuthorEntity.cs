namespace BookStore.Core.Entities
{
    public class AuthorEntity : BaseEntity
    {

        public string Name { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public ICollection<BookEntity>? Books { get; set; } = [];
    }
}
