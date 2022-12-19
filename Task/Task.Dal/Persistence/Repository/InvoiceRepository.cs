using Task.Task.Dal.Models;

namespace Task.Task.Dal.Persistence.Repository
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {

    }
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
