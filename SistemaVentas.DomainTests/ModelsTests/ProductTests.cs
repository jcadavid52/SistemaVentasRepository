using SistemaVentas.Domain.Exceptions;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.DomainTests.ModelsTests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_SinSuficienteStock_DebeMostrarBusinessException()
        {
            int quantity = 2;
            var product = Product.Create("Product1",700.1m,2,1);
            product.SubtractStock(quantity);

            Assert.Throws<BusinessException>(() =>
            {
                product.SufficientStock(quantity);
            });
        }
    }
}
