using MediatR;
using SistemaVentas.App.Dtos;

namespace SistemaVentas.App.OrderUseCases.Create
{
    public record CreateOrderCommand(
        int ClientId,
        List<OrderDetailRequestDto> Items
        ):IRequest<int>;
}
