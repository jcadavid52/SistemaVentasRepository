using SistemaVentas.Domain.Abstractions;
using SistemaVentas.Domain.Exceptions;

namespace SistemaVentas.Domain.Models
{
    public class Order:DomainEntity<int>
    {

        public string Status { get; private set; } = default!;

        public int ClientId { get; private set; }

        public Client Client { get; private set; } = default!;

        public ICollection<OrderDetail> OrderDetails { get; private set; } = [];

        public ICollection<Invoice> Invoices { get; private set; } = [];

        public static Order Create(int clientId,List<OrderDetail> orderDetails)
        {
            if(orderDetails.Count <= 0)
            {
                throw new BusinessException("Un pedido debe tener por lo menos un detalle de pedido");
            }

            return new Order
            {
                ClientId = clientId,
                Status = "Pendiente",
                OrderDetails = orderDetails
            };
        }

        public void CancelOrder()
        {
            if(Status == "Cancelado" || Status == "Pagado")
            {
                throw new BusinessException($"No se puede cancelar el pedido ya que se encuentra en estado '{Status}'");
            }

            Status = "Cancelado";
        }

        public void PayOrder()
        {
            Status = "Pagado";
        }
    }
}
