namespace SistemaVentas.App.Dtos
{
    public record OrderDto(int Id,string Status,DateTime CreateAt,ClientDto Client ,List<OrderDetailDto> OrderItem);
}
