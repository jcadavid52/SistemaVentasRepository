using SistemaVentas.Domain.Models;

namespace SistemaVentas.Domain.Ports
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<List<Order>> GetFilterAsync(string? Status, int? ClientId);
    }
}
