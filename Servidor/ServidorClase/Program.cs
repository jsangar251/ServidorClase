
using Microsoft.EntityFrameworkCore;
using ServidorClase.Database;
using ServidorClase.Database.Repositories;

namespace ServidorClase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<MyDataBase>(options =>
                options.UseSqlite($"DataSource={AppDomain.CurrentDomain.BaseDirectory}coches.db"));

            builder.Services.AddScoped<CarRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Asegurar que está creada la BBDD
            using (IServiceScope scope = app.Services.CreateScope())
            {
                MyDataBase database = scope.ServiceProvider.GetRequiredService<MyDataBase>();
                
                if (database.Database.EnsureCreated())
                {
                    Seeder seeder = new Seeder(database);
                    seeder.Seed();
                }
            }

            app.Run();
        }
    }
}
