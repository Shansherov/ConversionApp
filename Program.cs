using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moravia.Homework.Interfaces;

namespace Moravia.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            using var servicesProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<DocumentStorageService>()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(configuration);
                }).BuildServiceProvider();

            var fileStorageService = servicesProvider.GetRequiredService<DocumentStorageService>();
        }
    }
}