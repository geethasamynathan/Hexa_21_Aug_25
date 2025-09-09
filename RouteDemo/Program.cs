
using Microsoft.EntityFrameworkCore;
using RouteDemo.Models;
using RouteDemo.Repository;

namespace RouteDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IStudentRepo,StudentRepo>();
            // Add services to the container.
            builder.Services.AddDbContext<HexaMay25ApiCfDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HexaMay25APICfDbContext")));
            builder.Services.AddControllers();
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

            app.Run();
        }
    }
}
