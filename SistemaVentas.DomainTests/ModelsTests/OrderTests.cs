using SistemaVentas.Domain.Exceptions;
using SistemaVentas.Domain.Models;

namespace SistemaVentas.DomainTests.ModelsTests
{
    public class OrderTests
    {
        [Fact]
        public void CancelOrder_OrdenConStatusPagado_DebeMostrarBusinessException()
        {
            var orderDetails = new List<OrderDetail>();
            var orderDetail1 = OrderDetail.Create(5,1);
            var orderDetail2 = OrderDetail.Create(1,1);
            orderDetails.Add(orderDetail1);
            orderDetails.Add(orderDetail2);

            var order = Order.Create(1,orderDetails);
            order.PayOrder();

            Assert.Throws<BusinessException>(() =>
            {
                order.CancelOrder();
            });
        }

        [Fact]
        public void CancelOrder_OrdenConStatusCancelado_DebeMostrarBusinessException()
        {
            var orderDetails = new List<OrderDetail>();
            var orderDetail1 = OrderDetail.Create(5,1);
            var orderDetail2 = OrderDetail.Create(1,1);
            orderDetails.Add(orderDetail1);
            orderDetails.Add(orderDetail2);

            var order = Order.Create(1,orderDetails);
            order.CancelOrder();

            Assert.Throws<BusinessException>(() =>
            {
                order.CancelOrder();
            });
        }
    }
}
