using BookStore.Core.Common;

namespace BookStore.Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public BookEntity? Book { get; set; }
        public ClientEntity? Client { get; set; }
        public DateTime? Created { get; set; }
    }
}
