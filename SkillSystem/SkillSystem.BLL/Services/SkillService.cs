using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SkillSystem.BLL.Converter;
using SkillSystem.BLL.Dtos.SkillDto;
using SkillSystem.DataAccess.Entities;
using SkillSystem.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository SkillRepository;
    private readonly ILogger<SkillService> Logger;
   /* private readonly IMemoryCache MemoryCache;
    private const string SkillCacheKey = "skill_cache_key";*/


    public SkillService(ISkillRepository skillRepository, ILogger<SkillService> logger = null, IMemoryCache memoryCache = null)
    {
        SkillRepository = skillRepository;
        Logger = logger;
       // MemoryCache = memoryCache;
    }


    public async Task<ICollection<SkillGetDto>> GetAllAsync()
    {
        if (MemoryCache.TryGetValue(SkillCacheKey, out List<SkillGetDto> cachedSkills))
        {
            return cachedSkills;
        }
        var skills = await SkillRepository.SelectAllAsync();
        var skillsGetDto = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList();

        MemoryCache.Set(SkillCacheKey, skillsGetDto, TimeSpan.FromMinutes(10));

        return skillsGetDto;
    }

    public async Task<ICollection<SkillGetDto>> GetAllByUserIdAsync(long userId)
    {
        var skills = await SkillRepository.SelectAllByUserIdAsync(userId);
        var skillsGetDto = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList();

        return skillsGetDto;
    }

    public async Task<long> PostAsync(SkillCreateDto skillCreateDto)
    {
        var skill = Mappings.ConvertToSkill(skillCreateDto);
        var skillId = await SkillRepository.InsertAsync(skill);

        ClearCache();
        return skillId;
    }

    public Task<Skill?> UpdateAsync(Skill skill)
    {
        throw new NotImplementedException();

    }
    public Task<bool> DeleteAsync(long skillId)
    {
        throw new NotImplementedException();
    }
    private void ClearCache()
    {
        MemoryCache.Remove(SkillCacheKey);
    }

}
