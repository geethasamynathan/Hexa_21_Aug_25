using Microsoft.EntityFrameworkCore;
using ModelValidationDemo1.Models;

namespace ModelValidationDemo1.Contexts
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get;set;}
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.Address);
        }
    }
}
