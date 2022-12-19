using Microsoft.EntityFrameworkCore;
using Task.Task.Dal.Models;

namespace Task.Task.Dal.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
