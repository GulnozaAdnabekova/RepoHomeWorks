using EmployeeManagement.BLL.Dtos.UserDto;
using EmployeeManagement.Dal.Entities;
using EmployeeManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        return await UserRepository.SelectAllAsync();
      
    }

    public async Task<long> PostAsync(UserCreateDto userCreateDto)
    {
        var user = await UserRepository.InsertAsync(user);
        {
            user.Username = userCreateDto.Username;
            user.PasswordHash = userCreateDto.PasswordHash;
            user.Position = userCreateDto.Position;
            user.Role = userCreateDto.Role;
            user.Salary = userCreateDto.Salary;
        };

       
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto userUpdateDto)
    {
        var user = await UserRepository.SelectByIdAsync(userId);
        if (user == null)
            return false;

        user.Username = userUpdateDto.Username;
        user.PasswordHash = userUpdateDto.PasswordHash;
        user.Role = userUpdateDto.Role;
        user.Position = userUpdateDto.Position;
        user.Salary = userUpdateDto.Salary;

        await UserRepository.UpdateAsync(user);
        return true;
    }
    public async Task DeleteAsync(long userId)
    {
        await UserRepository.DeleteAsync(userId);
        
    }
}
