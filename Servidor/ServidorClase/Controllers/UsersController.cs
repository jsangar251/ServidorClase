using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;
using ServidorClase.Database.Entities;
using ServidorClase.Database.Repositories;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public UsersController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _unitOfWork.UserRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<User?> GetUser(int id)
    {
        return await _unitOfWork.UserRepository.GetByIdAsync(id);
    }

    /*
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

        _userRepository.Users.Remove(user);
        _userRepository.SaveChanges();

        return NoContent();
    }*/
}
