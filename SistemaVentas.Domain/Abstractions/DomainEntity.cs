namespace SistemaVentas.Domain.Abstractions
{
    public abstract class DomainEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
