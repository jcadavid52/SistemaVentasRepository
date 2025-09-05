using SistemaVentas.Domain.Abstractions;

namespace SistemaVentas.Domain.Models
{
    public class Invoice:DomainEntity<int>
    {
        const decimal taxation = 0.19m;
        public string InvoiceNumber { get; private set; } = default!;

        public decimal Iva { get; private set; }

        public decimal Subtotal { get; private set; }

        public decimal Total { get; private set; }

        public int OrderId { get; private set; }

        public Order Order { get; private set; } = default!;

        public static Invoice Create(Order order)
        {
            decimal subTotal = CalculateSubtotal(order.OrderDetails);
            decimal iva = subTotal * taxation;
            decimal total = subTotal + iva;

            return new Invoice
            {
                InvoiceNumber = Guid.NewGuid().ToString(),
                Subtotal = subTotal,
                Iva = iva,
                Total = total,
                OrderId = order.Id
            };
        }

        private static decimal CalculateSubtotal(ICollection<OrderDetail> Items)
        {  
            decimal subtotal = 0;

            foreach (var item in Items)
            {
                subtotal += item.Product.Price;
            }

            return subtotal;
        }

    }
}
