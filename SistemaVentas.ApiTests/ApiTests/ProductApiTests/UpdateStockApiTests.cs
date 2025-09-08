using SistemaVentas.ApiTests.DataBuilderApi;
using SistemaVentas.App.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace SistemaVentas.ApiTests.ApiTests.ProductApiTests
{
    public class UpdateStockApiTests(ApiApp apiApp):IClassFixture<ApiApp>
    {
        private readonly HttpClient _client = apiApp.CreateClient();
        private readonly ProductDataBuilder _productDataBuilder = new();

        [Fact]
        public async Task UpdateStock_CuandoSeActualizaCorrecto_RetornaStatus200()
        {
            //Arrange
            var command = _productDataBuilder
                .BuildUpdateStockCommand();

            //Act

            var response = await _client.PutAsJsonAsync($"{apiApp.PathProductApi}/{command.Id}/stock",command);

            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task UpdateStock_CuandoNoEncuentraProducto_RetornaStatus404()
        {
            //Arrange
            var command = _productDataBuilder
                .WithId(100)
                .BuildUpdateStockCommand();

            //Act
            var response = await _client.PutAsJsonAsync($"{apiApp.PathProductApi}/{command.Id}/stock",command);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        }

        [Fact]
        public async Task UpdateStock_CuandoSeActualizaCorrecto_RetornaElStockEsperado()
        {
            //Arrange
            int stockExpected = 15;
            var command = _productDataBuilder
                .WithStock(stockExpected)
                .BuildUpdateStockCommand();

            //Act
            var response = await _client.PutAsJsonAsync($"{apiApp.PathProductApi}/{command.Id}/stock",command);
            var content = await response.Content.ReadFromJsonAsync<ProductDto>();

            //Assert
            Assert.Equal(stockExpected,content!.Stock);
        }
    }
}
