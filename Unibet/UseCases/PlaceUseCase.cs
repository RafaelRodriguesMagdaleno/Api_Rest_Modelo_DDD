using Unibet.Entities;
using Unibet.DTOs.Request;
using Unibet.Entities;
using Unibet.Interfaces.IRepositories;
using Unibet.ValueObjects;

namespace Unibet.UseCases
{
    public class PlaceUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        public PlaceUseCase(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public void Run(PlaceRequest request)
        {
            try
            {
                User user = _userRepository.FindById(request.UserId);
                if (user == null)
                {
                    throw new Exception("User Invalido");
                }

                Game game = _gameRepository.FindById(request.GameId);
                if (game == null)
                {
                    throw new Exception("Jogo Invalido");
                }

                user.Debit(new Amount(request.Amount));
                game.Place(request.UserId, new Amount(request.Amount), new Team(request.Team));

                _userRepository.Update(user);
                _gameRepository.Update(game);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
