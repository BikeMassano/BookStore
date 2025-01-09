using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Services
{
    public interface IJwtProvider
    {
        public string GenerateToken(UserEntity userEntity);
    }
}