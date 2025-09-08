
using DemoAPI1.Models;
using DemoAPI1.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace DemoAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
         
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));
            builder.Services.AddScoped<IDepartmentCRUD, DepartmentCRUD>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeCRUD, EmployeeCRUD>();
            builder.Services.AddControllers();
            //builder.Services.AddControllers().AddJsonOptions( o=>
            //{
            //    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //    o.JsonSerializerOptions.WriteIndented = true;
            //});
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); //terminal middleware
        }
    }
}
