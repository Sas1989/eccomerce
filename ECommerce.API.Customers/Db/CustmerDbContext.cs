using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Customers.Db
{
    public class CustmerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustmerDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
