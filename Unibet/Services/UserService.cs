using Unibet.Entities;
using Unibet.DTOs;
using Unibet.Entities;
using Unibet.Interfaces.IRepositories;
using Unibet.Interfaces.IServices;

namespace Unibet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Deposit(DepositDTO depositDTO)
        {
            try
            {
                if (depositDTO == null)
                {
                    throw new Exception("Objeto de deposito invalido!");
                }

                if (depositDTO.DepositAmount <= 0)
                {
                    throw new Exception("Valor do deposito invalido!");
                }

                User savedUser = _userRepository.FindById(depositDTO.UserId);

                if (savedUser == null)
                {
                    throw new Exception("Coloca um usuario de verdade ai amigao!");
                }

                Deposit newDeposit = new Deposit();
                newDeposit.DepositAmount = depositDTO.DepositAmount;
                newDeposit.DepositType = depositDTO.DepositType;
                newDeposit.DateTime = DateTime.Now;
                newDeposit.UserId = depositDTO.UserId;

                // _depositRepository.Save(newDeposit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserData(int Id)
        {
            throw new NotImplementedException();
        }
    }
}