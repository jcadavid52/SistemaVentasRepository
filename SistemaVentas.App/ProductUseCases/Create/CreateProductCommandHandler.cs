using MediatR;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.ProductUseCases.Create
{
    public class CreateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(
                request.Name,
                request.Price,
                request.Stock,
                request.CategoryId
            );

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
