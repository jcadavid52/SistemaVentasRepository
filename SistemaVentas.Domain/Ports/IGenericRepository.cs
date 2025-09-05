namespace SistemaVentas.Domain.Ports
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> QueryAsync();

        Task<T?> GetByIdAsync(object id);

        Task AddAsync(T Entity);

        Task AddRangeAsync(IEnumerable<T> Entities);
    }
}
