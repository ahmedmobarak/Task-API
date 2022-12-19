using Task.Task.Dal.Persistence.Repository;

namespace Task.Task.Dal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Invoices = new InvoiceRepository(_context);
        }

        public ICustomerRepository Customers { get; set; }
        public IInvoiceRepository Invoices { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
