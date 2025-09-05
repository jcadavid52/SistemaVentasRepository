using MediatR;
using SistemaVentas.App.Extensions;
using SistemaVentas.App.Services;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.OrderUseCases.Create
{
    public class CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork,
        ClientService clientService,
        ProductService productService
        ) : IRequestHandler<CreateOrderCommand,int>
    {
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = await clientService.ValidateExistenceClient(request.ClientId);

            client.CheckCancelledOrdersByClient();

            var orderDetails = OrderExtension.BuildOrderDetail(request.Items);
            var order = Order.Create(request.ClientId,orderDetails);

            await orderRepository.AddAsync(order);
            await productService.SubtractStockAsync(request.Items);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
