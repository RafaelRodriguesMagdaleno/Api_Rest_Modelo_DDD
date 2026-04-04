using Unibet.ValueObjects;

namespace Unibet.Entities
{
    public class Bet : EntitiyBase
    {

        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public Amount Amount { get; set; }
        public Team Team { get; set; }

        public Bet(Guid gameId, Guid userId, Amount amount, Team team)
        {
            this.UserId = userId;
            this.Amount = amount;
            this.Team = team;
            this.GameId = gameId;
        }
    }
}
