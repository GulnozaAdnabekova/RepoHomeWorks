using CarSystem.DataAccess;
using CarSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Repository.Repositories;

public interface ICarRepository
{
    Task<long> InsertAsync(Car car);
    Task<ICollection<Car>> SelectAllAsync();
    Task<ICollection<Car>> SelectAllByPersonIdAsync(long personId);
    Task<Car?> UpdateAsync(Car car);
    Task DeleteAsync(Car car);
}
