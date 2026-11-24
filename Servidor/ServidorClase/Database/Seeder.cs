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
        SeedUsers();
        _dataBase.SaveChanges();

        SeedCars();
        _dataBase.SaveChanges();
    }

    private void SeedCars()
    {
        Car[] cars = [
            new Car {
                Name = "Renault",
                OwnerId = 1
            },
            new Car {
                Name = "Opel",
                Price = 300000,
                OwnerId = 2
            }
        ];

        _dataBase.AddRange(cars);
    }

    private void SeedUsers()
    {
        User[] users = [
            new User {
                Name = "Pepito",
                Email = "pepito@gmail.com",
                Password = "1234"
            },
            new User {
                Name = "Pepito2",
                Email = "pepito2@gmail.com",
                Password = "1234"
            }
        ];

        _dataBase.AddRange(users);
    }
}
