using MediatR;
using SistemaVentas.App.Dtos;
using System.Text.Json.Serialization;

namespace SistemaVentas.App.OrderUseCases.Pay
{
    public record PayOrderCommand(string PayMethod) : IRequest<InvoiceDto>
    {
        [JsonIgnore]
        public int OrderId { get; init; }
    }
}
