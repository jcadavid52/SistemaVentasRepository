using Microsoft.EntityFrameworkCore;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data.Repositories
{
    [Repository]
    public class OrderRepository(DataContext dataContext):GenericRepository<Order>(dataContext),IOrderRepository
    {
        public override async Task<Order?> GetByIdAsync(object id)
        {
            return await QueryAsync()
                .Include(order => order.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(od => od.Category)
                .Include(order => order.Client)
                .FirstOrDefaultAsync(order => order.Id == (int)id);
        }

        public Task<List<Order>> GetFilterAsync(string? status, int? clientId)
        {
            var query = QueryAsync().AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(order => order.Status.Contains(status));

            if (clientId.HasValue)
                query = query.Where(order => order.ClientId == clientId);

            return query
                .Include(order => order.OrderDetails)
                    .ThenInclude(orderDetail => orderDetail.Product)
                    .ThenInclude(product => product.Category)
                .Include(order => order.Client)
                .ToListAsync();
        }
    }
}
