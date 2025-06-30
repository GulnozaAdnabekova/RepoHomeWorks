using CarSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Repository.Repositories;

public interface IPersonReporitory
{
    Task<long> InsertAsync(Person person);
    Task<ICollection<Person>> SelectAllAsync();
    Task<Person> SelectByIdAsync(long personId);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
}
