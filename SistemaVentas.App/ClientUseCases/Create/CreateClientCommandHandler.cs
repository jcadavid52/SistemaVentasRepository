using MediatR;
using SistemaVentas.App.Services;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.ClientUseCases.Create
{
    public class CreateClientCommandHandler(
        IClientRepository clientRepository,
        IUnitOfWork unitOfWork,
        ClientService clientService
        ) : IRequestHandler<CreateClientCommand, int>
    {
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            await clientService.ValidateExistenceEmail(request.Email);

            var client = Client.Create(
                request.Name,
                request.Email,
                request.PhoneNumber,
                request.Address
            );

            await clientRepository.AddAsync(client);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
