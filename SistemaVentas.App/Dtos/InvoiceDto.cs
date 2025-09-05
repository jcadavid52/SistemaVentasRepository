namespace SistemaVentas.App.Dtos
{
    public record InvoiceDto(
        int Id,
        string InvoiceNumber,
        decimal Iva,
        decimal Subtotal,
        decimal Total,
        int OrderId,
        DateTime CreatAt,
        List<OrderDetailDto> Detail,
        ClientDto Client
    );
}
