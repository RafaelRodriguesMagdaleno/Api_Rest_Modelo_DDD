namespace Unibet.DTOs.Request
{
    public class PlaceRequest
    {
        public decimal Amount { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public string Team { get; set; }
    }
}
