using CarSystem.Bll.DTOs.CarDto;
using CarSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Bll.Services
{
    public interface ICarService
    {
        Task<long> PostAsync(CarCreateDto carCreateDto);
        Task<ICollection<CarGetDto>> GetAllAsync();
        Task<ICollection<CarGetDto>> GetAllByPersonIdAsync(long userId);
        Task<Car?> UpdateAsync(Car car);
        Task<bool> DeleteAsync(long carId);
    }
}
