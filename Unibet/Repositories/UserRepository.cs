using Unibet.Entities;
using Unibet.Data.Contexts;
using Unibet.Entities;
using Unibet.Interfaces.IRepositories;

namespace Unibet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _database;
        public UserRepository()
        {
        }

        public User FindById(Guid userId)
        {
            User user = _database.Users
                .Select(usr => usr)
                .Where(usr => usr.Id == userId).FirstOrDefault();

            return user;
        }
    }
}