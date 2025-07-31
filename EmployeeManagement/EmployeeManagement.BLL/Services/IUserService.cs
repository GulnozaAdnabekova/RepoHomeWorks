using EmployeeManagement.BLL.Dtos.UserDto;
using EmployeeManagement.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL.Services
{
    public interface IUserService
    {
        Task<long> PostAsync(UserCreateDto userCreateDto);
        Task<ICollection<User>> GetAllAsync();
        Task<bool> UpdateAsync(long userId, UserUpdateDto userUpdateDto);
        Task DeleteAsync(long userId);
    }
}
