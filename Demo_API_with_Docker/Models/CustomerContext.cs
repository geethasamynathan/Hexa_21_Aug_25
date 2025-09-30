using Microsoft.EntityFrameworkCore;

namespace Demo_API_with_Docker.Models
{
    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
