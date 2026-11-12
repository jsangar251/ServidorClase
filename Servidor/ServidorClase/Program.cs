
using ServidorClase.Database;

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

            builder.Services.AddScoped<MyDataBase>();

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
                database.Database.EnsureCreated();
            }

            app.Run();
        }
    }
}
