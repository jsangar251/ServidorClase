using ServidorClase.Database.Entities;

namespace ServidorClase.Database.Repositories;

public class CarRepository : Repository<Car, int>
{
    public CarRepository(MyDataBase context) : base(context)
    {
    }
}
