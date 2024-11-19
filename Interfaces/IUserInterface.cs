using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Interfaces
{
    public interface IUserInterface
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(int model);
        public Task<User> CreateUser(User model);
        public Task<User> UpdateUser(User model);
        public Task DeleteUser(User model);
    }
}