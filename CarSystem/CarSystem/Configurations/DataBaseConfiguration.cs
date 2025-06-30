using CarSystem.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.Api.Configurations;

public static class DataBaseConfiguration
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
