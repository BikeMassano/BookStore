using System.ComponentModel.DataAnnotations;

namespace BookStore.WebAPI.Contracts
{
    public record UserLoginRequest
    {
        [Required]
        public string UserName { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
