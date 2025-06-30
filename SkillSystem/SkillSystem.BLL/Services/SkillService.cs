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
    public SkillService(ISkillRepository skillRepository)
    {
        SkillRepository = skillRepository;
    }


    public async Task<ICollection<SkillGetDto>> GetAllAsync()
    {
        var skills = await SkillRepository.SelectAllAsync();
        var skillsGetDto = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList();

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
}
