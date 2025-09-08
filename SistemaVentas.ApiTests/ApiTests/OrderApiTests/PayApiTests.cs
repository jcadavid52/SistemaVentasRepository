using SistemaVentas.ApiTests.ApiTests.Common;
using SistemaVentas.ApiTests.DataBuilderApi;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.OrderApiTests
{
    public class PayApiTests(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly OrderApiTestsCommon _orderApiTestsCommon = new(apiApp);

        [Fact]
        public async Task PayOrder_OrderExistente_RetornaStatus200()
        {
            //Arrange
            int id = await _orderApiTestsCommon.CreateOrderHttpAsync();

            var commandPay = new
            {
                PayMethod = "TDC"
            };

            //Act
            var responsePayOrder = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}/{id}/pay", commandPay);
            //Assert
            Assert.Equal(HttpStatusCode.OK, responsePayOrder.StatusCode);
        }
    }
}
