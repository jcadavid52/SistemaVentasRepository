using SistemaVentas.ApiTests.ApiTests.Common;
using SistemaVentas.ApiTests.DataBuilderApi;
using SistemaVentas.App.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.OrderApiTests
{
    public class GetAllApiTests(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly OrderApiTestsCommon _orderApiTestsCommon = new(apiApp);

        [Fact]
        public async Task GetOrders_DebeObtenerMinimoDosPedidos_RetornaStatus200()
        {
            //Arrange
            await _orderApiTestsCommon.CreateOrderHttpAsync(3);
            await _orderApiTestsCommon.CreateOrderHttpAsync();

            //Act
            var response = await _client.GetAsync($"{apiApp.PathOrderApi}");
            var content = await response.Content.ReadFromJsonAsync<List<OrderDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.NotNull( content );
            Assert.True(content!.Count >= 2);
        }
    }
}
