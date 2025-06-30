using SkillSystem.BLL.Dtos.SkillDto;
using SkillSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Services;

public interface ISkillService
{
    Task<long> PostAsync(SkillCreateDto skillCreateDto);
    Task<ICollection<SkillGetDto>> GetAllAsync();
    Task<ICollection<SkillGetDto>> GetAllByUserIdAsync(long userId);
    Task<Skill?> UpdateAsync(Skill skill);
    Task<bool> DeleteAsync(long skillId);
}
