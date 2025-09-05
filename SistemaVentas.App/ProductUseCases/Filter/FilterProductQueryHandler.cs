using MediatR;
using SistemaVentas.App.Dtos;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.ProductUseCases.Filter
{
    public class FilterProductQueryHandler(
        IProductRepository productRepository
        ) : IRequestHandler<FilterProductQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(FilterProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetFilterAsync(
                request.CategoryId,
                request.MinPrice,
                request.MaxPrice
                );

            var productsDto = ProductExtension.ToProductsDto(products);

            return productsDto;
        }
    }
}
