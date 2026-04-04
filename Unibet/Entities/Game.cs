using Unibet.Entities;
using Unibet.ValueObjects;

namespace Unibet.Entities
{
    public class Game : EntitiyBase
    {
        public string Name { get; private set; }
        public decimal OddATeam { get; private set; }
        public decimal OddBTeam { get; private set; }
        public decimal OddHouse { get; private set; }
        public string ATeam { get; private set; }
        public string BTeam { get; private set; }
        public DateTime SortDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        private List<Bet> _bets { get; set; }
        public IReadOnlyCollection<Bet> Bets => _bets.AsReadOnly();

        public Game(string name, string aTeam, string bTeam,
            decimal oddA, decimal oddB, decimal oddHouse,
            DateTime sortDate, DateTime finishDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Nome invalido");
            }

            if (string.IsNullOrEmpty(aTeam))
            {
                throw new Exception("ATeam nulo!");
            }

            if (string.IsNullOrEmpty(bTeam))
            {
                throw new Exception("BTeam nulo!");
            }

            this.Name = name;
            this.ATeam = aTeam;
            this.BTeam = bTeam;
            this.OddATeam = oddA;
            this.OddBTeam = oddB;
            this.OddHouse = oddHouse;
            this.FinishDate = finishDate;
            this.SortDate = sortDate;
            this.CreatedAt = DateTime.Now;
        }

        public void Edit(string name, DateTime sortDate, DateTime finishDate)
        {
            // validacoes necessarias 

            this.Name = name;
            this.SortDate = sortDate;
            this.FinishDate = finishDate;
        }

        public void Place(Guid userId, Amount amount, Team team)
        {
            Bet bet = new Bet(this.Id, userId, amount, team);
            _bets.Add(bet);
        }
    }
}
