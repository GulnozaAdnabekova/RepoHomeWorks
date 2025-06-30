using SkillSystem.BLL.Dtos.UserDto;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Services;

public interface IUserService
{
    Task<long> PostAsync(UserCreateDto userCreateDto);
    Task<ICollection<UserGetDto>> GetAllAsync();
    Task<bool> UpdateAsync(long userId, UserUpdateDto userUpdateDto);
    Task<bool> DeleteAsync(long userId);
}
