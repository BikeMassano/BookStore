using System.ComponentModel.DataAnnotations;

namespace BookStore.WebAPI.Contracts
{
    public record UserRegistrationRequest 
    {
        [Required]
        public string UserName {  get; init; }
        [Required]
        public string Password { get; init; }
        public string Adress {  get; init; }
        public string PhoneNumber {  get; init; }
        [Required]
        public string Email { get; init; } 
    }
}
