using MediatR;

namespace SistemaVentas.App.ProductUseCases.Create
{
    public record CreateProductCommand(string Name,
        decimal Price,
        int Stock,
        int CategoryId
        ):IRequest<int>;
}
