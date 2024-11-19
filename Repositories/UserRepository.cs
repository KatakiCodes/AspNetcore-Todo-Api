using Microsoft.EntityFrameworkCore;
using TodoAspNetAPI.Data;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Repositories
{
    public class UserRepository : IUserInterface
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<User> CreateUser(User model)
        {
            await this._appDbContext.Users.AddAsync(model);
            await this._appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteUser(User model)
        {
            this._appDbContext.Remove(model);
            await this._appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int Id)
        {
            User? user = await this._appDbContext.Users.Include(x => x.Targets).Where(x => x.Id == Id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this._appDbContext.Users.Include(x => x.Targets).ToListAsync();
            return users;
        }

        public async Task<User> UpdateUser(User model)
        {
            this._appDbContext.Entry<User>(model).State = EntityState.Modified;
            await this._appDbContext.SaveChangesAsync();
            return model;
        }
    }
}