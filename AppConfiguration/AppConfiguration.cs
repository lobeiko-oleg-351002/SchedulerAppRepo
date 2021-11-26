using Microsoft.Extensions.Configuration;
using System;

namespace AppConfiguration
{
    public static class AppConfiguration
    {
        public static IAppSettings GetAppSettings(string environmentName, string filePath)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true);

            IConfigurationRoot configuration = builder.Build();

            IAppSettings settings = new AppSettings();
            configuration.Bind(settings);
            return settings;
        }
    }
}
