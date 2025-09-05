namespace SistemaVentas.Domain.Models
{
    public class OrderDetail
    {
        public int Quantity { get; private set; }

        public int OrderId { get; private set; }

        public Order Order { get; private set; } = default!;

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = default!;

        public static OrderDetail Create(int quantity,int productId)
        {
            return new OrderDetail
            {
                Quantity = quantity,
                ProductId = productId
            };
        }
    }
}
