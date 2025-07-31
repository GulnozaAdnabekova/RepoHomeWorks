using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using SkillSystem.BLL.Converter;
using SkillSystem.BLL.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IValidator<UserCreateDto> Validator;
        private readonly ILogger<UserService> Logger;
        public UserService(IUserRepository userRepository, IValidator<UserCreateDto> validator, ILogger<UserService> logger)
        {
            UserRepository = userRepository;
            Validator = validator;
            Logger = logger;
        }


        public async Task<ICollection<UserGetDto>> GetAllAsync()
        {
            var users = await UserRepository.SelectAllAsync();
            var usersDto = users.Select(u => Mappings.ConvertToUserGetDto(u)).ToList();
            return usersDto;
        }

        public async Task<long> PostAsync(UserCreateDto userCreateDto)
        {
            var result=Validator.Validate(userCreateDto);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var user = Mappings.ConvertToUser(userCreateDto);
            var userId = await UserRepository.InsertAsync(user);

            Logger.LogInformation("User created successfully with ID:{UserId}", userId);
            return userId;
        }

        public async Task<bool> UpdateAsync(long userId, UserUpdateDto userUpdateDto)
        {
            var user = await UserRepository.SelectByIdAsync(userId);
            if (user == null)
                return false;

            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.UserName= userUpdateDto.UserName;
            user.Password= userUpdateDto.Password;
            user.Email= userUpdateDto.Email;

            await UserRepository.UpdateAsync(user);
            return true;
        }
        public async Task<bool> DeleteAsync(long userId)
        {
            var user = await UserRepository.SelectByIdAsync(userId);
            if (user == null)
                return false;

            await UserRepository.DeleteAsync(user);
            return true;
        }
    }
}
