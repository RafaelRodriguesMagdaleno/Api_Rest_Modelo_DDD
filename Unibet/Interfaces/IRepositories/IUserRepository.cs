using Unibet.Entities;
using Unibet.Entities;

namespace Unibet.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User FindById(Guid userId);
        public User Update(User user);
        public User Save(User user);
    }
}