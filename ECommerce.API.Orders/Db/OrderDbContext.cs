using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Orders.Db
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions options) : base(options) { }
    }
}
