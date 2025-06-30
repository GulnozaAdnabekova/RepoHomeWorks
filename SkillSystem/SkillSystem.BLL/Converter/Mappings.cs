using SkillSystem.BLL.Dtos.SkillDto;
using SkillSystem.BLL.Dtos.UserDto;
using SkillSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSystem.BLL.Converter;

public static class Mappings
{
    public static UserGetDto ConvertToUserGetDto(User user)
    {
        return new UserGetDto()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Password=user.Password,
            Email=user.Email,
            SkillDtos = user.Skills == null ? new List<SkillGetDto>() : user.Skills.Select(s => ConvertToSkillGetDto(s)).ToList(),
        };
    }

    public static User ConvertToUser(UserCreateDto userCreatedto)
    {
        return new User()
        {
            FirstName = userCreatedto.FirstName,
            LastName = userCreatedto.LastName,
            UserName = userCreatedto.UserName,
            Password = userCreatedto.Password,
            Email = userCreatedto.Email,
        };
    }

    public static SkillGetDto ConvertToSkillGetDto(Skill skill)
    {
        return new SkillGetDto()
        {
            SkillId = skill.SkillId,
            Type = skill.Type,
            Name = skill.Name,
            Description = skill.Description,
            UserId = skill.UserId,
            Level = (SkillLevelDto)skill.Level
        };
    }

    public static Skill ConvertToSkill(SkillCreateDto skillCreateDto)
    {
        return new Skill()
        {
            Type = skillCreateDto.Type,
            Name = skillCreateDto.Name,
            Description = skillCreateDto.Description,
            Level = (SkillLevel)skillCreateDto.Level,
            UserId = skillCreateDto.UserId,
        };
    }
}
