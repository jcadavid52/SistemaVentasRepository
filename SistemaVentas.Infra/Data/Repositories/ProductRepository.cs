using Microsoft.EntityFrameworkCore;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data.Repositories
{
    [Repository]
    public class ProductRepository(DataContext dataContext) : GenericRepository<Product>(dataContext), IProductRepository
    {
        public override async Task<Product?> GetByIdAsync(object id)
        {
            return await QueryAsync()
                .Include(product => product.Category)
                .FirstOrDefaultAsync(product => product.Id == (int)id);
        }

        public async Task<List<Product>> GetFilterAsync(int? categoryId, decimal? minPrice, decimal? maxPrice)
        {
            var query = QueryAsync().AsQueryable();

            if (minPrice.HasValue)
                query = query.Where(product => product.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(product => product.Price <= maxPrice);

            if (categoryId.HasValue)
                query = query.Where(product => product.CategoryId == categoryId);

            return await query
                .Include(product => product.Category)
                .ToListAsync();
        }
    }
}
