using Microsoft.AspNetCore.Mvc;

namespace AspNet_Api_EfCore.Configurations
{
    public static class AppSettingsConfig
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .Build();
    }
}
