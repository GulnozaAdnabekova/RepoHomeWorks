using SkillSystem.BLL.Dtos.SkillDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Dtos.UserDto;

public class UserGetDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public List<SkillGetDto> SkillDtos { get; set; }
}
