using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;
using ServidorClase.Database.Entities;
using ServidorClase.Database.Repositories;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly MyDataBase _dataBase;

    public UsersController(MyDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    [HttpGet]
    public IEnumerable<User> GetAllUsers()
    {
        return _dataBase.Users;
    }

    [HttpGet("byname/{name}")]
    public IEnumerable<User> GetAllUsersByName(string name)
    {
        string lowerName = name.ToLower();

        return _dataBase.Users
            .Where(car => car.Name.ToLower().Contains(name));
    }

    [HttpGet("{id}")]
    public User? GetUser(int id)
    {
        return _dataBase.Users.Find(id);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        User user = new User
        {
            Id = id,
            Name = string.Empty,
            Email = string.Empty,
            Password = string.Empty
        };

        _dataBase.Users.Remove(user);
        _dataBase.SaveChanges();

        return NoContent();
    }
}
