using SistemaVentas.Domain.Models;
using SistemaVentas.Domain.Ports;

namespace SistemaVentas.Infra.Data.Repositories
{
    [Repository]
    public class InvoiceRepository(DataContext dataContext)
        :GenericRepository<Invoice>(dataContext),IInvoiceRepository
    {
    }
}
