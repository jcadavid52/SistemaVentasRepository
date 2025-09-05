using SistemaVentas.App.Dtos;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.App.Extensions
{
    public static class ProductExtension
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto(
                  product.Id,
                  product.Name,
                  product.Price,
                  product.Stock,
                  new CategoryDto(
                      product.Category.Id,
                      product.Category.Name
                  )
            );
        }

        public static List<ProductDto> ToProductsDto(this List<Product> products)
        {
            var productsDto = products
                .Select(product =>
                new ProductDto(
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Stock,
                    new CategoryDto(
                        product.Category.Id,
                        product.Category.Name
                        )
                    )
                ).ToList();

            return productsDto;
        }
    }
}
