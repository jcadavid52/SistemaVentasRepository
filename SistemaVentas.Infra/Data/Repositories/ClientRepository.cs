using Microsoft.EntityFrameworkCore;
using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data.Repositories
{
    [Repository]
    public class ClientRepository(DataContext dataContext) : GenericRepository<Client>(dataContext), IClientRepository
    {

        public override async Task<Client?> GetByIdAsync(object id)
        {
            return await QueryAsync()
                .Include(client => client.Orders)
                .FirstOrDefaultAsync(client => client.Id == (int)id);
        }

        public async Task<string?> GetByEmailAsync(string email)
        {
            return await QueryAsync()
                .Where(x => x.Email == email)
                .Select(cliente => cliente.Email)
                .FirstOrDefaultAsync();
        }
    }
}
