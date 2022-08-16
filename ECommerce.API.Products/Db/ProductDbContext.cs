using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Products.Db
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
