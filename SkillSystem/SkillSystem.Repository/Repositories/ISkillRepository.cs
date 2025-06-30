using SkillSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.Repository.Repositories;

public interface ISkillRepository
{
    Task<long> InsertAsync(Skill skill);
    Task<ICollection<Skill>> SelectAllAsync();
    Task<ICollection<Skill>> SelectAllByUserIdAsync(long userId);
    Task<Skill?> UpdateAsync(Skill skill);
    Task<bool> DeleteAsync(long skillid);
}
