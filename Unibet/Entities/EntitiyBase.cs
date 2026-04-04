namespace Unibet.Entities
{
    public class EntitiyBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public EntitiyBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }
    }
}
