using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServidorClase.Database;
using ServidorClase.Database.Entities;
using ServidorClase.Database.Repositories;
using ServidorClase.Servicies;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarService _carService;

    public CarsController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carService.GetAllCarsAsync();
    }

    [HttpGet("{id}")]
    public async Task<Car?> GetCarAsync(int id)
    {
        return await _carService.GetCarAsync(id);
    }

    [HttpGet("byname/{name}")]
    public async Task<IEnumerable<Car>> GetAllCarsByNameAsync(string name)
    {
        return await _carService.GetAllCarsByNameAsync(name);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> AddCarAsync([FromBody] Car newCar)
    {
        Car car = await _carService.AddCarAsync(newCar);

        return Created($"cars/{car.Id}", car);
    }

    [HttpPut("{carId}/changeOwner/{nameOwner}")]
    public async Task<ActionResult> ChangeOwnerAsync(int carId, string nameOwner)
    {
        await _carService.ChangeOwnerAsync(carId, nameOwner);

        return Ok();
    }

    /*
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
