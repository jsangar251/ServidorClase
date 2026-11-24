using Microsoft.EntityFrameworkCore;
using ServidorClase.Database.Repositories;

namespace ServidorClase.Database;

public class UnitOfWork
{
    private readonly MyDataBase _context;

    public CarRepository CarRepository { get; set; }
    public UserRepository UserRepository { get; set; }

    public UnitOfWork(MyDataBase context)
    {
        _context = context;

        CarRepository = new CarRepository(context);
        UserRepository = new UserRepository(context);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
