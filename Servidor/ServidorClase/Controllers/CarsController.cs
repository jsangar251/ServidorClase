using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;
using ServidorClase.Database.Entities;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly MyDataBase _dataBase;

    public CarsController(MyDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    [HttpGet]
    public IEnumerable<Car> GetAllCars()
    {
        return _dataBase.Cars;
    }

    [HttpGet("byname/{name}")]
    public IEnumerable<Car> GetAllCarsByName(string name)
    {
        string lowerName = name.ToLower();

        return _dataBase.Cars
            .Where(car => Equal(car, lowerName));
    }

    private bool Equal(Car car, string name)
    {
        return car.Name.ToLower().Contains(name);
    }

    [HttpGet("{id}")]
    public Car? GetCar(int id)
    {
        return _dataBase.Cars.Find(id);
    }

    [HttpPost]
    public ActionResult<Car> AddCar([FromBody] Car newCar)
    {
        _dataBase.Cars.Add(newCar);
        _dataBase.SaveChanges();

        return Created($"cars/{newCar.Id}", newCar);
    }
    /*
    [HttpDelete("{id}")]
    public ActionResult DeleteCar(int id)
    {
        cars.RemoveAll(car => car.Id == id);

        return NoContent();
    }*/
}
