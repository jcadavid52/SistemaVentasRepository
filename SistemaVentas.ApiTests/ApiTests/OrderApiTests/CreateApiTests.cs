using SistemaVentas.ApiTests.DataBuilderApi;
using SistemaVentas.App.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.OrderApiTests
{
    public class CreateApiTests(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly OrderDataBuider _orderDataBuilder = new();

        [Fact]
        public async Task CreateOrder_CuandoSeCreaCorrecto_Retorna201()
        {
            //Arrange
            var detailOrder1 = new OrderDetailRequestDto(1,1);
            var detailOrder2 = new OrderDetailRequestDto(2,1);
            var orderDetails = new List<OrderDetailRequestDto>();
            orderDetails.Add(detailOrder1);
            orderDetails.Add(detailOrder2);

            var command = _orderDataBuilder
                .BuildOrderDetailRequest(orderDetails)
                .BuildCreateOrderCommand();

            //Act
            var response = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}", command);

            //Assert
            Assert.Equal(HttpStatusCode.Created,response.StatusCode);
        }

        [Fact]
        public async Task CreateOrder_CuandoClienteNoSeEncuentra_Retorna404()
        {
            //Arrange
            var command = _orderDataBuilder
                .WithClientId(100)
                .BuildCreateOrderCommand();

            //Act
            var response = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}", command);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateOrder_CuandoEnviaOrderDetailVacio_RetornaStatus400()
        {
            //Arrange
            var command= _orderDataBuilder
                .BuildCreateOrderCommand();
            //Act
            var response = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}", command);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
