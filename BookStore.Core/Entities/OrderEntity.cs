namespace BookStore.Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public Guid BookId { get; set; }
        public BookEntity? Book { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime? Created { get; set; }
    }
}
