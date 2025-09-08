using SistemaVentas.ApiTests.DataBuilderApi;
using SistemaVentas.App.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace SistemaVentas.ApiTests.ApiTests.Common
{
    public class OrderApiTestsCommon(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly OrderDataBuider _orderDataBuilder = new();

        public async Task<int> CreateOrderHttpAsync(int clientId = 1)
        {
            var detailOrder1 = new OrderDetailRequestDto(1, 1);
            var detailOrder2 = new OrderDetailRequestDto(2, 1);
            var orderDetails = new List<OrderDetailRequestDto>();
            orderDetails.Add(detailOrder1);
            orderDetails.Add(detailOrder2);

            var command = _orderDataBuilder
                .WithClientId(clientId)
                .BuildOrderDetailRequest(orderDetails)
                .BuildCreateOrderCommand();

            var response = await _client.PostAsJsonAsync($"{apiApp.PathOrderApi}", command);
            var content = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(content);
            var root = doc.RootElement;
            int id = root.GetProperty("id").GetInt32();

            return id;
        }
    }
}
