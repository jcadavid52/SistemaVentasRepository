using Microsoft.EntityFrameworkCore;
using SistemaVentas.App.Exceptions;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data
{
    public class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await dataContext.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
            }
        }
    }
}
