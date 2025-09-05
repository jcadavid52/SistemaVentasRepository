using MediatR;

namespace SistemaVentas.App.OrderUseCases.Cancel
{
    public record CancelOrderCommand(int OrderId):IRequest<string>;
}
