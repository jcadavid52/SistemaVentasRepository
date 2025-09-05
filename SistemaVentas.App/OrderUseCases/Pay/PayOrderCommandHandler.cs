using MediatR;
using SistemaVentas.App.Dtos;
using SistemaVentas.App.Exceptions;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.OrderUseCases.Pay
{
    public class PayOrderCommandHandler(
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork,
        IInvoiceRepository invoiceRepository
        ) : IRequestHandler<PayOrderCommand, InvoiceDto>
    {
        public async Task<InvoiceDto> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetByIdAsync(request.OrderId) ??
                throw new NotFoundException("No se encontró pedido");

            order.PayOrder();

            var invoice = Invoice.Create(
                order
            );

            await invoiceRepository.AddAsync(invoice);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var invoiceDto = OrderExtension.ToInvoiceDto(order, invoice);

            return invoiceDto;
        }
    }
}
