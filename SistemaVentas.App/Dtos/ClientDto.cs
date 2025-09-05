namespace SistemaVentas.App.Dtos
{
    public record ClientDto(int Id,
        string Name,
        string Email,
        string PhoneNumber,
        string Address
    );
}
