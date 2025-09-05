namespace SistemaVentas.App.Dtos
{
    public record ProductDto(int Id,string Name,decimal Price,int Stock,CategoryDto Category );
}
