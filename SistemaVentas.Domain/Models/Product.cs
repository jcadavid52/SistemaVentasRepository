using SistemaVentas.Domain.Abstractions;
using SistemaVentas.Domain.Exceptions;

namespace SistemaVentas.Domain.Models
{
    public class Product:DomainEntity<int>
    {
        public string Name { get; private set; } = default!;

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; private set; } = default!;

        public ICollection<OrderDetail> OrderDetails { get; private set; } = [];

        public static Product Create(string name, decimal price, int stock, int categoryId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(stock);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(categoryId);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            return new Product
            {
                Name = name,
                Price = price,
                Stock = stock,
                CategoryId = categoryId
            };
        }

        public void UpdateStock(int stock)
        {
            Stock = stock;
        }

        public void SubtractStock(int quantity)
        {
            Stock -= quantity;
        }

        public void SufficientStock(int quantity)
        {
            if(quantity > Stock)
            {
                throw new BusinessException($"El producto '{Name}' no tiene stock suficiente");
            }
        }
    }
}
