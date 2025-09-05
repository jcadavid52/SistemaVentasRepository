using MediatR;
using SistemaVentas.App.Dtos;
using System.Text.Json.Serialization;

namespace SistemaVentas.App.ProductUseCases.UpdateStock
{
    public record UpdateStockProductCommand(int Stock):IRequest<ProductDto>
    {
        [JsonIgnore]
        public int Id { get; init; }
    }
}
