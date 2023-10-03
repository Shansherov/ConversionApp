using System.Reflection.PortableExecutable;

using Microsoft.Extensions.Configuration;

namespace shared.auxilliary;

public static class ConfigUtils
{
    public static T? GetAppData<T>(IConfiguration config, string section) where T : class
    {
        try
        {
            var result = config.GetSection(section).Get<T>();

            if (result == null) throw new ArgumentNullException("Application section equals null");

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Method [GetAppData] has failed with error: {ex.Message}");
            throw;
        }
    }
    public static IConfiguration InitConfiguration()
    {
        var config = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.json", optional: false)
           .Build();
        return config;
    }
}


