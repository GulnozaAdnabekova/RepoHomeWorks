using SkillSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Dtos.SkillDto;

public class SkillCreateDto
{
    public string Type { get; set; }
    public string Name { get; set; }
    public SkillLevelDto Level { get; set; }
    public string Description { get; set; }

    public long UserId { get; set; }
}
public enum SkillLevelDto
{
    Elementary,
    PreIntermediate,
    Intermediate,
    UpperIntermediate,
    Advanced,
    Expert,
    Master
}
