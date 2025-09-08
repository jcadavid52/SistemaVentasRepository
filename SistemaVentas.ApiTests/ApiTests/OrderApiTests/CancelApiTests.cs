using SistemaVentas.ApiTests.ApiTests.Common;
using SistemaVentas.ApiTests.DataBuilderApi;
using SistemaVentas.App.Dtos;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SistemaVentas.ApiTests.ApiTests.OrderApiTests
{
    public class CancelApiTests(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly OrderApiTestsCommon _orderApiTestsCommon = new(apiApp);

        [Fact]
        public async Task CancelOrder_OrdenExistente_RetornaStatus200()
        {
            //Arrange
            int id = await _orderApiTestsCommon.CreateOrderHttpAsync();

            var commandCancel = new
            {
                id
            };

            //Act
            var responseCancelOrder = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}/{commandCancel.id}/cancel", id);

            //Assert
            Assert.Equal(HttpStatusCode.OK,responseCancelOrder.StatusCode);
        }

        [Fact]
        public async Task CancelOrder_OrdenNoExistente_RetornaStatus404()
        {
            //Arrange
            var command = new
            {
                id = 100
            };

            //Act
            var responseCancelOrder = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}/{command.id}/cancel", command.id);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, responseCancelOrder.StatusCode);
        }
    }
}
