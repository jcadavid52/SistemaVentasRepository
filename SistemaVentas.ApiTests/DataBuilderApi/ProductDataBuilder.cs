using SistemaVentas.App.ProductUseCases.Create;
using SistemaVentas.App.ProductUseCases.UpdateStock;

namespace SistemaVentas.ApiTests.DataBuilderApi
{
    public class ProductDataBuilder
    {
        private int _id = 1;
        private string _name = "producto test";
        private decimal _price = 800.00m;
        private int _stock = 10;
        private int _categoryId = 1;

        public ProductDataBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public ProductDataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductDataBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public ProductDataBuilder WithStock(int stock)
        {
            _stock = stock;
            return this;
        }

        public ProductDataBuilder WithCategoryId(int categoryId)
        {
            _categoryId = categoryId;
            return this;
        }

        public CreateProductCommand BuildCreateCommand()
        {
            return new CreateProductCommand(
                _name,
                _price,
                _stock,
                _categoryId
            );
        }

        public UpdateStockProductCommand BuildUpdateStockCommand()
        {
            return new UpdateStockProductCommand(_stock)
            {
                Id = _id,
            };
        }
    }
}
