using Microsoft.AspNetCore.Mvc;
using ServidorClase.Database;
using ServidorClase.Database.Entities;

namespace ServidorClase.Servicies;

public class CarService
{
    private readonly UnitOfWork _unitOfWork;

    public CarService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _unitOfWork.CarRepository.GetAllCarsWithOwnerAsync();
    }

    public async Task<Car?> GetCarAsync(int id)
    {
        return await _unitOfWork.CarRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Car>> GetAllCarsByNameAsync(string name)
    {
        return await _unitOfWork.CarRepository.GetAllCarsByNameAsync(name);
    }

    public async Task<Car> AddCarAsync(Car newCar)
    {
        Car car = await _unitOfWork.CarRepository.InsertAsync(newCar);
        await _unitOfWork.SaveAsync();

        return car;
    }

    public async Task ChangeOwnerAsync(int carId, string nameOwner)
    {
        Car? car = await _unitOfWork.CarRepository.GetByIdAsync(carId);

        if (car is not null)
        {
            User? newOwner = await _unitOfWork.UserRepository.GetUserByNameAsync(nameOwner);

            if (newOwner is not null)
            {
                car.OwnerId = newOwner.Id;
            }
        }

        await _unitOfWork.SaveAsync();
    }
}
