using Microsoft.EntityFrameworkCore;
using ServidorClase.Database.Entities;

namespace ServidorClase.Database;

public class MyDataBase : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }

    public MyDataBase(DbContextOptions options)
        : base(options) { }
}
