using MediatR;
using SistemaVentas.App.Dtos;
using SistemaVentas.App.Exceptions;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.ProductUseCases.UpdateStock
{
    public class UpdateStockProductCommandHandler (
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
        ): IRequestHandler<UpdateStockProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(UpdateStockProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id) ??
                throw new NotFoundException("No se encontró entidad");

            product.UpdateStock(request.Stock);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var productDto = ProductExtension.ToProductDto(product);

            return productDto;
        }
    }
}
