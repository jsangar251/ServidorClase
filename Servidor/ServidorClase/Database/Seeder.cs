using ServidorClase.Database.Entities;

namespace ServidorClase.Database;

public class Seeder
{
    private readonly MyDataBase _dataBase;

    public Seeder(MyDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    public void Seed()
    {
        Car[] cars = [
            new Car {
                Name = "Renault"
            },
            new Car {
                Name = "Opel",
                Price = 300000
            }
        ];

        _dataBase.AddRange(cars);
        _dataBase.SaveChanges();
    }
}
