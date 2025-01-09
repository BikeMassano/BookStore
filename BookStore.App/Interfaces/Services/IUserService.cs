using BookStore.Core.Entities;

namespace BookStore.App.Interfaces.Services
{
    public interface IUserService
    {
        public Task Register(string name, string password, string adress, string phoneNumber, string email);
        public Task<string> Login(string userName, string password);
    }
}
