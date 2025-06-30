using CarSystem.DataAccess;
using CarSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Repository.Repositories;

public class CarRepository : ICarRepository
{
    private readonly MainContext MainContext;
    public CarRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }


    public async Task<long> InsertAsync(Car car)
    {
        await MainContext.Cars.AddAsync(car);
        await MainContext.SaveChangesAsync();
        return car.CarId;
    }

    public async Task<ICollection<Car>> SelectAllAsync()
    {
        /*var cars = await MainContext.Cars
            .Include(u => u.Cars)
            .ToListAsync();

        return cars;*/
        var cars = await MainContext.Cars.ToListAsync();
        return cars;
    }

    public async Task<ICollection<Car>> SelectAllByPersonIdAsync(long carId)
    {
        /*var car = await MainContext.Cars.FirstOrDefaultAsync(u => u.CarId == carId);

        if (car == null)
        {
            throw new Exception($"User with id : {carId} not found");
        }

        await MainContext.Entry(car).Collection(u => u.Cars).LoadAsync();

        return car;*/
        var query = MainContext.Cars.Where(s => s.CarId == carId);
        var cars = await query.ToListAsync();
        return cars;
    }

    public  async Task<Car?> UpdateAsync(Car car)
    {
        var existing = await MainContext.Cars.FindAsync(car.CarId);
        if (existing == null) return null;

        existing.Name = car.Name;
        existing.Brand = car.Brand;
        existing.PersonId = car.PersonId;

        await MainContext.SaveChangesAsync();
        return existing;
    }
    public async Task DeleteAsync(Car car)
    {
        MainContext.Cars.Remove(car);
        await MainContext.SaveChangesAsync();

        /*var skill = await MainContext.Cars.FindAsync(carId);
        if (skill == null) return false;

        MainContext.Cars.Remove(car);
        await MainContext.SaveChangesAsync();
        return true;*/
    }
}
