using Identity.Bll.Dtos;
using Identity.Dal.Entities;
using Identity.Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Identity.Bll.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository UserRepository;
    private readonly IConfiguration Config;
    private readonly SignInManager<User> SignInManager;

    public AuthService(IUserRepository userRepository, IConfiguration config)
    {
        UserRepository = userRepository;
        Config = config;
        //SignInManager = signInManager;
    }

    public async Task<RefreshTokenDto> LoginAsync(LoginDto dto)
    {
        var user = await UserRepository.GetByEmailAsync(dto.Email);
        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        var result = await SignInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Invalid credentials");

        var accessToken = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await UserRepository.UpdateAsync(user);


        return new RefreshTokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
    }



    public async Task LogoutAsync(string email)
    {
        var user = await UserRepository.GetByEmailAsync(email);
        if (user != null)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.MinValue;
            await UserRepository.UpdateAsync(user);
        }
    }

    public async Task<RefreshTokenDto> RefreshTokenAsync(string refreshToken)
    {
        var user = await UserRepository.GetByEmailAsync(""); // You'd match by refresh token ideally

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            throw new SecurityTokenException("Invalid refresh token");

        var newAccessToken = GenerateJwtToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await UserRepository.UpdateAsync(user);

        return new RefreshTokenDto { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
    }

    public async Task<RefreshTokenDto> RegisterAsync(RegisterDto dto)
    {

        var user = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            UserName = dto.UserName,
            Password= dto.Password,
            Email = dto.Email
        };

        await UserRepository.CreateAsync(user, dto.Password);

        var accessToken = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await UserRepository.UpdateAsync(user);

        return new RefreshTokenDto { AccessToken = accessToken, RefreshToken = refreshToken };
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Config["Jwt:Issuer"],
            audience: Config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

}


