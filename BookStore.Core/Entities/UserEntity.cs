using BookStore.Core.Enums;

namespace BookStore.Core.Entities
{
    public class UserEntity :  BaseEntity
    {
        public Role Role { get; set; } = Role.User;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<OrderEntity>? Orders { get; set; } = [];
    }
}
