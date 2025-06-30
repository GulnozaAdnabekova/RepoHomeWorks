using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess;
using SkillSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.Repository.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly MainContext MainContext;

    public SkillRepository(MainContext mainContext)
    {
        MainContext=mainContext;
    }


    public async Task<long> InsertAsync(Skill skill)
    {
        await MainContext.Skills.AddAsync(skill);
        await MainContext.SaveChangesAsync();
        return skill.SkillId;
    }

    public async Task<ICollection<Skill>> SelectAllAsync()
    {
        var skills=await MainContext.Skills.ToListAsync();
        return skills;
    }

    public async Task<ICollection<Skill>> SelectAllByUserIdAsync(long userId)
    {
        var query= MainContext.Skills.Where(s=>s.UserId== userId);
        var skills=await query.ToListAsync();
        return skills;
    }

    public async Task<Skill?> UpdateAsync(Skill skill)
    {
        var existing = await MainContext.Skills.FindAsync(skill.SkillId);
        if (existing == null) return null;

        existing.Name = skill.Name;
        existing.Level = skill.Level;
        existing.UserId = skill.UserId;

        await MainContext.SaveChangesAsync();
        return existing;
    }
    public async Task<bool> DeleteAsync(long skillid)
    {
        var skill = await MainContext.Skills.FindAsync(skillid);
        if (skill == null) return false;

        MainContext.Skills.Remove(skill);
        await MainContext.SaveChangesAsync();
        return true;
    }
}
