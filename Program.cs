using ConversionApp.auxilliary;
using ConversionApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace ConversionApp
{
    class Program
    {
        /// <summary>
        /// Main method for the application which handles configuration and application services
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            using var servicesProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .ConfigureServices(configuration)
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(configuration);
                }).BuildServiceProvider();

            var documentService = servicesProvider.GetRequiredService<IDocumentService>();

            // Call ConvertAndSaveDocument method directly using the interface
            documentService.ConvertAndSaveDocument();
        }

        
    }
}