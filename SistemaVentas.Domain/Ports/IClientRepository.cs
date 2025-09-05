using SistemaVentas.Domain.Models;

namespace SistemaVentas.Domain.Ports
{
    public interface IClientRepository:IGenericRepository<Client>
    {
        Task<string?> GetByEmailAsync(string email);
    }
}
