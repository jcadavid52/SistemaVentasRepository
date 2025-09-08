using SistemaVentas.App.Dtos;
using SistemaVentas.App.OrderUseCases.Create;

namespace SistemaVentas.ApiTests.DataBuilderApi
{
    public class OrderDataBuider
    {
        private int _clientId = 1;
        private List<OrderDetailRequestDto> _orderDetailRequestDtos = [];

        public OrderDataBuider WithClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }

        public OrderDataBuider BuildOrderDetailRequest(List<OrderDetailRequestDto> orderDetailRequestDtos)
        {
            _orderDetailRequestDtos = orderDetailRequestDtos;
            return this;
        }

        public CreateOrderCommand BuildCreateOrderCommand()
        {
            return new CreateOrderCommand(
                _clientId,
                _orderDetailRequestDtos
            );
        }
    }
}
