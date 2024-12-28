using BookStore.Core.Common;

namespace BookStore.Core.Entities
{
    public class ClientEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<OrderEntity>? Orders { get; set; } = [];
    }
}
