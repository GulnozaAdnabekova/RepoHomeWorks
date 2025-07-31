using Identity.Bll.Dtos;

namespace Identity.Bll.Services
{
    public interface IAuthService
    {
        Task<RefreshTokenDto> RegisterAsync(RegisterDto dto);
        Task<RefreshTokenDto> LoginAsync(LoginDto dto);
        Task<RefreshTokenDto> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(string email);
        /*public Task<long> SignUpAsync(RegisterDto registerDto);
        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);*/
    }
}