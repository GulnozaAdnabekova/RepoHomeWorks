using Identity.Bll.Dtos;
using Identity.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

//[Route("api/[controller]")]
[Route("public/v1/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService AuthService;

    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }


    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterDto dto)
        => Ok(await AuthService.RegisterAsync(dto));



    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
        => Ok(await AuthService.LoginAsync(dto));



    [HttpPost("refresh-token")]
    public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        => Ok(await AuthService.RefreshTokenAsync(refreshToken));



    [HttpPost("log-out")]
    public async Task<IActionResult> Logout([FromBody] string email)
    {
        await AuthService.LogoutAsync(email);
        return Ok();
    }
}
