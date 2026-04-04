using Unibet.Entities;
using Unibet.ValueObjects;

namespace Unibet.Entities
{
    public class User : EntitiyBase
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Amount Amount { get; set; }
        public virtual List<Deposit> Deposits { get; set; }

        public void Debit(Amount amount)
        {
            if (this.Amount.Value < amount.Value)
            {
                throw new Exception("Saldo Insuficiente");
            }

            this.Amount.Value -= amount.Value;
        }
    }
}
