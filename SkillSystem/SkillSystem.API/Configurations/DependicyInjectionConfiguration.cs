
using FluentValidation;
using FluentValidation.AspNetCore;
using SkillSystem.BLL.Dtos.UserDto;
using SkillSystem.BLL.Services;
using SkillSystem.BLL.Validators;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.API.Configurations;

public static class DependicyInjectionConfiguration
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<ISkillService, SkillService>();

        builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();

    }
}
