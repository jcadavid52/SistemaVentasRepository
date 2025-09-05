using Microsoft.EntityFrameworkCore;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data.Repositories
{
    public class GenericRepository<T>(DataContext dataContext) : IGenericRepository<T> where T : class
    {
        public IQueryable<T> QueryAsync()
        {
            return dataContext.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await dataContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T Entity)
        {
            await dataContext.Set<T>().AddAsync(Entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> Entities)
        {
            await dataContext.AddRangeAsync(Entities);
        }
    }
}
