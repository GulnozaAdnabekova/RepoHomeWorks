﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Dtos.SkillDto;

public class SkillGetDto
{
    public long SkillId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public SkillLevelDto Level { get; set; }
    public string Description { get; set; }

    public long UserId { get; set; }
}

