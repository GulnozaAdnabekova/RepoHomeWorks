using CarSystem.Bll.Services;
using CarSystem.Repository.Repositories;

namespace CarSystem.Api.Configurations
{
    public static class DependicyInjectionConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
           
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();

            builder.Services.AddValidatorsFromAssemblyContaining<PersonCreateDtoValidator>();

        }
    }

    
}
