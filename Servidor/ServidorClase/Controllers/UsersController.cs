using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;
using ServidorClase.Database.Entities;
using ServidorClase.Database.Repositories;
using ServidorClase.Dtos;
using ServidorClase.Servicies;

namespace ServidorClase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        IEnumerable<User> users = await _userService.GetAllUsersAsync();
        List<UserDto> userDtos = [];

        foreach (User user in users)
        {
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            userDtos.Add(userDto);
        }

        return userDtos;
    }

    [HttpGet("{id}")]
    public async Task<UserDto?> GetUserAsync(int id)
    {
        User? user = await _userService.GetUserAsync(id);
        UserDto? userDto;

        if (user is not null)
        {
            userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        } 
        else
        {
            userDto = null;
        }

        return userDto;
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
