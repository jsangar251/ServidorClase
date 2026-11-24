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
    private readonly UnitOfWork _unitOfWork;

    public CarsController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _unitOfWork.CarRepository.GetAllCarsWithOwnerAsync();
    }

    [HttpGet("{id}")]
    public async Task<Car?> GetCar(int id)
    {
        return await _unitOfWork.CarRepository.GetByIdAsync(id);
    }

    [HttpGet("byname/{name}")]
    public async Task<IEnumerable<Car>> GetAllCarsByNameAsync(string name)
    {
        return await _unitOfWork.CarRepository.GetAllCarsByNameAsync(name);
    }

    [HttpPost]
    public async Task<ActionResult<Car>> AddCarAsync([FromBody] Car newCar)
    {
        Car car = await _unitOfWork.CarRepository.InsertAsync(newCar);
        await _unitOfWork.SaveAsync();

        return Created($"cars/{car.Id}", car);
    }

    [HttpPut("{carId}/changeOwner/{nameOwner}")]
    public async Task ChangeOwnerAsync(int carId, string nameOwner)
    {
        Car? car = await _unitOfWork.CarRepository.GetByIdAsync(carId);

        if (car is not null)
        {
            User? newOwner = await _unitOfWork.UserRepository.GetUserByNameAsync(nameOwner);

            if (newOwner is not null)
            {
                //car.Owner = newOwner;
                car.OwnerId = newOwner.Id;
            }
        }

        await _unitOfWork.SaveAsync();
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
