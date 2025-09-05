using SistemaVentas.App.Exceptions;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.App.Services
{
    [ApplicationService]
    public class ClientService(
        IClientRepository clientRepository
        )
    {
        public async Task ValidateExistenceEmail(string email)
        {
            var resultEmail = await clientRepository.GetByEmailAsync(email);

            if( resultEmail != null )
            {
                throw new ExistenceEmailException("El email que intenta registrar ya existe en el sistema");
            }
        }

        public async Task<Client> ValidateExistenceClient(int clientId)
        {
            return await clientRepository.GetByIdAsync(clientId) ??
                 throw new NotFoundClientException("El cliente no existe en el sistema");
        }
    }
}
