using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServidorClase.Database;
using ServidorClase.Database.Entities;
using ServidorClase.Database.Repositories;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarRepository _carRepository;

    public CarsController(CarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carRepository.GetAllAsync();
    }

    /*
    [HttpGet("byname/{name}")]
    public IEnumerable<Car> GetAllCarsByName(string name)
    {
        string lowerName = name.ToLower();

        return _dataBase.Cars
            .Where(car => car.Name.ToLower().Contains(name));
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

    [HttpPut("{id}")]
    public ActionResult<Car> UpdateCar(int id, [FromBody] Car newCar)
    {
        newCar.Id = id;
        EntityEntry<Car> entry = _dataBase.Cars.Update(newCar);
        _dataBase.SaveChanges();

        return Ok(entry.Entity);
    }

    [HttpPut("{id}/name")]
    public ActionResult<Car> UpdateCarName(int id, [FromBody] Car newCar)
    {
        Car? car = _dataBase.Cars.Find(id);

        if (car is not null)
        {
            car.Name = newCar.Name;
            _dataBase.Cars.Update(car);
            _dataBase.SaveChanges();
        }        

        return NoContent();
    }


    [HttpDelete("{id}")]
    public ActionResult DeleteCar(int id)
    {
        Car car = new Car { Id = id, Name = string.Empty }; //;_dataBase.Cars.Find(id);
        _dataBase.Cars.Remove(car);
        _dataBase.SaveChanges();

        return NoContent();
    }*/
}
