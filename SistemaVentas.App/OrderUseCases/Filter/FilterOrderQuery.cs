using MediatR;
using SistemaVentas.App.Dtos;

namespace SistemaVentas.App.OrderUseCases.Filter
{
    public record FilterOrderQuery(string? Status,int? ClientId):IRequest<List<OrderDto>>;
}
