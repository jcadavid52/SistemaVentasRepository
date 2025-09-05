using MediatR;
using SistemaVentas.App.Dtos;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.OrderUseCases.Filter
{
    public class FilterOrderQueryHandler(
        IOrderRepository orderRepository
        ) : IRequestHandler<FilterOrderQuery, List<OrderDto>>
    {
        public async Task<List<OrderDto>> Handle(FilterOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetFilterAsync(request.Status,request.ClientId);

            var ordersDto  = OrderExtension.ToOrdersDto(orders);

            return ordersDto;
        }
    }
}
