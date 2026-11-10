namespace ServidorClase.Database;

public class MyDataBase
{
    private List<Car> cars;

    public MyDataBase()
    {
        cars = new List<Car>();
    }

    public IEnumerable<Car> GetAll()
    {
        return cars;
    }

    public void Add(Car newCar)
    {
        cars.Add(newCar);
    }
}
