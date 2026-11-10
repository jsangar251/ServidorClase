using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;

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
        return _dataBase.GetAll();
    }

    [HttpPost]
    public ActionResult<Car> AddCar([FromBody] Car newCar)
    {
        _dataBase.Add(newCar);

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
