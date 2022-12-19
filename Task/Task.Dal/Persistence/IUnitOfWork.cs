using Task.Task.Dal.Persistence.Repository;

namespace Task.Task.Dal.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IInvoiceRepository Invoices { get; }
        int Complete();
    }
}
