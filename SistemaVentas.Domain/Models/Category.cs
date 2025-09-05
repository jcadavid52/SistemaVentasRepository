using SistemaVentas.Domain.Abstractions;

namespace SistemaVentas.Domain.Models
{
    public class Category:DomainEntity<int>
    {
        public string Name { get; private set; } = default!;

        public ICollection<Product> Products { get; private set; } = [];

        public static Category Create(string name)
        {
            return new Category
            {
                Name = name
            };
        }
    }
}
