using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DemoWebApi.Extensions
{
    public static class HostBuilderExtensions
    {
        internal static IHostBuilder SetEnvironment(this IHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return builder;
        }
    }
}
