using Task.Task.Dal.Models;

namespace Task.Task.Dal.Persistence.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
