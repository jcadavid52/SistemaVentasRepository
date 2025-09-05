using SistemaVentas.Domain.Models;

namespace SistemaVentas.Domain.Ports
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> GetFilterAsync(int? categoryId, decimal? minPrice,decimal? maxPrice);
    }
}
