using BookStore.App.Interfaces.Repository;
using BookStore.App.Interfaces.Services;
using BookStore.Core.Entities;
using BookStore.Core.Enums;

namespace BookStore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IJwtProvider _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository repository, IJwtProvider jwtService, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task Register(string userName, string password, string adress, string phoneNumber, string email)
        {
            var user = new UserEntity
            {
                Role = Role.User,
                Id = Guid.NewGuid(),
                UserName = userName,
                Address = adress,
                Email = email,
                PhoneNumber = phoneNumber,
                IsDeleted = false
            };

            var passHash = _passwordHasher.HashPassword(password);
            user.PasswordHash = passHash;

            await _repository.AddAsync(user);
        }

        public async Task<string> Login(string userName, string password)
        {
            var user = await _repository.GetByNameAsync(userName);

            var result = _passwordHasher.VerifyPassword(password, user.PasswordHash);

            if (result == true)
            {
                return _jwtService.GenerateToken(user);
            }
            else
            {
                throw new Exception("Unauthorized");
            }

        }

    }
}
