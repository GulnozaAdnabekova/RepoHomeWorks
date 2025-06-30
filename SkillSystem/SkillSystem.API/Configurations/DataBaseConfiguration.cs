using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess;
using Microsoft.Extensions.Options;

namespace SkillSystem.API.Configurations
{
    public static  class DataBaseConfiguration
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

            //builder.Services.AddDbContext<MainContext>(options =>
            //  options.UseNpgsql(connectionString));

            builder.Services.AddDbContext<MainContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
