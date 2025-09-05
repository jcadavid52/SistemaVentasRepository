using MediatR;
using SistemaVentas.App.Exceptions;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.OrderUseCases.Cancel
{
    public class CancelOrderCommandHandler(
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CancelOrderCommand, string>
    {
        public async Task<string> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.OrderId) ??
                throw new NotFoundException("No se encontró pedido");

            order.CancelOrder();

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Cancelado con exito";
        }
    }
}
