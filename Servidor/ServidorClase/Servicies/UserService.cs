using ServidorClase.Database;
using ServidorClase.Database.Entities;

namespace ServidorClase.Servicies;

public class UserService
{
    private readonly UnitOfWork _unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _unitOfWork.UserRepository.GetAllAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _unitOfWork.UserRepository.GetByIdAsync(id);
    }
}
