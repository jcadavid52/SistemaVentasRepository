using SistemaVentas.App.Dtos;
using SistemaVentas.App.Exceptions;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.Services
{
    [ApplicationService]
    public class ProductService(
        IProductRepository productRepository
        )
    {
        public async Task SubtractStockAsync(List<OrderDetailRequestDto> items)
        {
            foreach (var item in items)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId) ??
                    throw new NotFoundException("No se encontró producto");

                product.SufficientStock(item.Quantity);
                product.SubtractStock(item.Quantity);
            }
        }
    }
}
