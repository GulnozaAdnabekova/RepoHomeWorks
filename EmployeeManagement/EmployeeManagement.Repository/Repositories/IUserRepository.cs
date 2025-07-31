using EmployeeManagement.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repositories;

public interface IUserRepository
{
    Task<long> InsertAsync(User user);
    Task<ICollection<User>> SelectAllAsync();
    Task<User> SelectByIdAsync(long userId);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task DeleteAsync(long userId);
}
