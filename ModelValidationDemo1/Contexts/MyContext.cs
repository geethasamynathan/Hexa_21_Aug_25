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
            //modelBuilder.Entity<Employee>()
            //    .OwnsOne(e => e.Address);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasData(
                new Department { Id = 1, Name = "HR", Location = "New York" },
                           new Department { Id = 2, Name = "IT", Location = "San Francisco" },
                           new Department { Id = 3, Name = "Finance", Location = "Chicago" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Geetha",
                    LastName = "Samynathan",
                    Phone = "9500774477",
                    Email = "geethasamynathan2011@gmail.com",
                    Salary = 9000,
                    DateOfBirth = new DateTime(1985, 10, 08),
                    DateOfJoining = new DateTime(2008, 03, 08),
                    EmployeeType = EmployeeType.Contract,
                    DepartmentId = 1,
                },
                 new Employee
                 {
                     Id = 2,
                     FirstName = "Fransy",
                     LastName = "Sam",
                     Phone = "9500774488",
                     Email = "fransy@gmail.com",
                     Salary = 9000,
                     DateOfBirth = new DateTime(1990, 10, 08),
                     DateOfJoining = new DateTime(2014, 03, 08),
                     EmployeeType = EmployeeType.Permanent,
                     DepartmentId = 2,
                 }
                );
        }
    }
}
