using Microsoft.Extensions.Configuration;
using SauceDemoTests.Models;

namespace SauceDemoTests.Helpers;

public static class ConfigurationReader
{
    public static TestSettings GetSettings()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var settings = new TestSettings();

        configuration.Bind(settings);

        return settings;
    }
}