using Unibet.Entities;
using Unibet.DTOs;
using Unibet.Entities;

namespace Unibet.Interfaces.IServices
{
    public interface IUserService
    {
        public User GetUserData(int Id);
        public void Deposit(DepositDTO depositDTO);
    }
}
