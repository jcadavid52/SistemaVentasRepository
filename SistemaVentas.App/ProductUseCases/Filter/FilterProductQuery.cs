using MediatR;
using SistemaVentas.App.Dtos;

namespace SistemaVentas.App.ProductUseCases.Filter
{
    public record FilterProductQuery(
        int? CategoryId,
        decimal? MaxPrice,
        decimal? MinPrice
        ):IRequest<List<ProductDto>>;
}
