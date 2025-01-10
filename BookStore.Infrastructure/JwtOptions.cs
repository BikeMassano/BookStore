using System.ComponentModel.DataAnnotations;

namespace BookStore.Infrastructure
{
    public class JwtOptions
    {
        [Required]
        public TimeSpan Expires { get; set; }
        [Required]
        public string SecretKey { get; set; } = string.Empty;
    }
}
