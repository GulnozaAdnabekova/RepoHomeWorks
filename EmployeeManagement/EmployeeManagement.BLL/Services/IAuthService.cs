using EmployeeManagement.BLL.Dtos;
using EmployeeManagement.BLL.Dtos.UserDto;

namespace EmployeeManagement.BLL.Services
{
    public interface IAuthService
    {
        public Task<long> SignUpAsync(UserCreateDto userCreateDto);
        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);

    }
}