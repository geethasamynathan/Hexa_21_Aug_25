using Microsoft.EntityFrameworkCore;

namespace DemoAPI1.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Department> Departments { get; set; } //Table 
        public DbSet<Employee> Employees { get; set; } //Table
        public DbSet<Customer> Customers { get; set; } //Table
    }
}
