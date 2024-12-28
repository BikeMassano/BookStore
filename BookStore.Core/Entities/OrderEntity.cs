namespace BookStore.Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public Guid BookId { get; set; }
        public BookEntity? Book { get; set; }
        public Guid ClientId { get; set; }
        public ClientEntity? Client { get; set; }
        public DateTime? Created { get; set; }
    }
}
