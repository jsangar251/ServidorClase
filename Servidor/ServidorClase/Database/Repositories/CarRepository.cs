using Microsoft.EntityFrameworkCore;
using ServidorClase.Database.Entities;

namespace ServidorClase.Database.Repositories;

public class CarRepository : Repository<Car, int>
{
    public CarRepository(MyDataBase context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> GetAllCarsByNameAsync(string name, bool asNoTracking = true)
    {
        string lowerName = name.ToLower();

        return await GetQueryable(asNoTracking)
            .Where(car => car.Name.ToLower().Contains(name))
            .ToArrayAsync();
    }

    public async Task<IEnumerable<Car>> GetAllCarsWithOwnerAsync()
    {
        return await GetQueryable()
            .Include(car => car.Owner)
            .ToArrayAsync();
    }
}
