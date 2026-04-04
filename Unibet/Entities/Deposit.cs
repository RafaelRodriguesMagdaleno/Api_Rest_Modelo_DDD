namespace Unibet.Entities
{
    public class Deposit : EntitiyBase
    {
        public float DepositAmount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string DepositType { get; set; }
        public DateTime DateTime { get; set; }
    }
}
