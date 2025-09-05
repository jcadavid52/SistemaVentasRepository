using MediatR;

namespace SistemaVentas.App.ClientUseCases.Create
{
    public record CreateClientCommand(
        string Name,
        string Email,
        string PhoneNumber,
        string Address
        ):IRequest<int>;
}
