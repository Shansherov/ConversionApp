using ConversionApp.Configuration;
using ConversionApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConversionApp.auxilliary;

/// <summary>
/// Configuration utils
/// </summary>
public static class ConfigUtils
{
    /// <summary>
    /// Method gets data out of the configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="config"></param>
    /// <param name="section"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
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
    /// <summary>
    /// Initialize configuration from appsettings.json file
    /// </summary>
    /// <returns></returns>
    public static IConfiguration InitConfiguration()
    {
        var config = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.json", optional: false)
           .Build();
        return config;
    }

    /// <summary>
    /// Configure required services using appsettings json file
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            // Load settings from appsettings.json
            var conversionSettings = configuration.GetSection("ConversionSettings").Get<ConversionSettings>();

            if (conversionSettings is null) throw new ArgumentNullException($"The configuration section: {nameof(conversionSettings)} has not been found in appsettings");

            services.AddScoped<IDocumentService>(provider =>
            {
                var inputFormat = conversionSettings.InputFormat switch
                {
                    "XML" => (IDocumentFormat)new XMLFormat(),
                    "YAML" => (IDocumentFormat)new YAMLFormat(),
                    _ => (IDocumentFormat)new JSONFormat()
                };

                var outputFormat = conversionSettings.OutputFormat switch
                {
                    "XML" => (IDocumentFormat)new XMLFormat(),
                    "YAML" => (IDocumentFormat)new YAMLFormat(),
                    _ => (IDocumentFormat)new JSONFormat()
                };

                var inputStorage = conversionSettings.InputStorage switch
                {
                    "FileStorage" => (IStorage)new FileStorage(),
                    "CloudStorage" => (IStorage)new CloudStorage(),
                    _ => (IStorage)new FileStorage()
                };
                var outputStorage = conversionSettings.OutputStorage switch
                {
                    "FileStorage" => (IStorage)new FileStorage(),
                    "CloudStorage" => (IStorage)new CloudStorage(),
                    _ => (IStorage)new FileStorage()
                };

                var logger = provider.GetRequiredService<ILogger<DocumentService>>();

                return new DocumentService(
                    inputStorage,
                    outputStorage,
                    inputFormat,
                    outputFormat,
                    conversionSettings.SourceFileName,
                    conversionSettings.TargetFileName,
                    logger);
            });

            return services;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Method [ConfigureServices] has failed with error: {ex.Message}");
            throw;
        }
    }
}


