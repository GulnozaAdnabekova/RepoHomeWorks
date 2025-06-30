using CarSystem.Api.Converter;
using CarSystem.Bll.DTOs.CarDto;
using CarSystem.Bll.DTOs.PersonDto;
using CarSystem.DataAccess.Entities;
using CarSystem.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Bll.Services;

public class CarService : ICarService
{
    private readonly ICarRepository CarRepository;
    public CarService(ICarRepository carRepository)
    {
        CarRepository = carRepository;
    }

    public async Task<ICollection<CarGetDto>> GetAllAsync()
    {
        var cars=await CarRepository.SelectAllAsync();
        var carsGetDto=cars.Select(s=>Mappings.ConvertToPersonGetDto(s)).ToList();
        return carsGetDto;
    }

    public async Task<ICollection<CarGetDto>> GetAllByPersonIdAsync(long personId)
    {
        var cars = await CarRepository.SelectAllByPersonIdAsync(personId);
        var carsGetDto = cars.Select(s => Mappings.ConvertTocarGetDto(s)).ToList();

        return carsGetDto;
    }

    public async Task<long> PostAsync(CarCreateDto carCreateDto)
    {
        var car= Mappings.ConvertToCar(carCreateDto);
        var carId=await CarRepository.InsertAsync(car);
      

        return carId;
    }

    public Task<Car?> UpdateAsync(Car car)
    {
        throw new NotImplementedException();
        /* var car = await CarRepository.SelectByIdAsync(personId);
         if (person == null)
             return false;

         car.Brand = carUpdateDto.Brand;
         car.Name = carUpdateDto.Name;
         */
    }
    public Task<bool> DeleteAsync(long carId)
    {
        throw new NotImplementedException();
    }
}
