using Microsoft.AspNetCore.Mvc;
using SkillSystem.BLL.Dtos.UserDto;
using SkillSystem.BLL.Services;

namespace SkillSystem.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService UserService;

    public UserController(IUserService userService)
    {
        UserService = userService;
    }

    [HttpPost("add")]
    public async Task<long> PostUser(UserCreateDto userCreateDto)
    {
        return await UserService.PostAsync(userCreateDto);
    }

    [HttpGet("get-all")]
    public async Task<ICollection<UserGetDto>> GetAll()
    {
        return await UserService.GetAllAsync();
    }

    [HttpPut("update{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UserUpdateDto userUpdateDto)
    {
        var updated = await UserService.UpdateAsync(id, userUpdateDto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("delete{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await UserService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
