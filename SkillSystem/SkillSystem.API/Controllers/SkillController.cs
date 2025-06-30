using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillSystem.BLL.Dtos.SkillDto;
using SkillSystem.BLL.Services;

namespace SkillSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService SkillService;

    public SkillController(ISkillService skillService)
    {
        SkillService = skillService;
    }
   

    [HttpPost("add")]
    public async Task<long> PostSkill(SkillCreateDto skillCreateDto)
    {
        return await SkillService.PostAsync(skillCreateDto);
    }

    [HttpGet("getAll")]
    public async Task<ICollection<SkillGetDto>> GetAll()
    {
        return await SkillService.GetAllAsync();
    }

    [HttpGet("getAllByUserId/{userId}")]
    public async Task<ICollection<SkillGetDto>> GetAllByUserId(long userId)
    {
        return await SkillService.GetAllByUserIdAsync(userId);
    }
}
