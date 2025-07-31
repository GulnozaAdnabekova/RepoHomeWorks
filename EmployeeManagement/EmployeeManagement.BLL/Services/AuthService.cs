using EmployeeManagement.BLL.Dtos;
using EmployeeManagement.BLL.Dtos.UserDto;
using EmployeeManagement.Repository.Repositories;

namespace EmployeeManagement.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository UserRepository;

    public AuthService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }

    public Task<long> SignUpAsync(UserCreateDto userCreateDto)
    {
        throw new NotImplementedException();
    }
}
