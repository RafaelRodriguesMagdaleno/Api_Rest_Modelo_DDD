namespace Unibet.DTOs
{
    public class DepositDTO
    {
        public float DepositAmount { get; set; }
        public string DepositType { get; set; }
        public Guid UserId { get; set; }
    }
}
