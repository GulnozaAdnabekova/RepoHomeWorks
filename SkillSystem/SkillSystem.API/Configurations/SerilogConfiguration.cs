using Serilog;

namespace SkillSystem.API.Configurations
{
    public static class SerilogConfiguration
    {
        public static void ConfigureSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .CreateLogger();

            builder.Logging.ClearProviders(); // Remove default logging providers
            builder.Logging.AddSerilog(dispose: true); // Add Serilog as the logging provider
        }
    }
}
