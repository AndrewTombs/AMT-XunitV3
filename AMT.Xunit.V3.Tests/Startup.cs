using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AMT.Xunit.V3.Tests;

public class Startup
{
    public void ConfigureHost(IHostBuilder hostBuilder) =>
        hostBuilder.ConfigureAppConfiguration((context, builder) =>
        {
            // Explicitly get environment name from the variable we control in the workflow.
            // This bypasses any inconsistent behavior in the test host's environment resolution.
            var environmentName = System.Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

            // Build configuration
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(); // Load all environment variables
        });

    public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        // The IConfiguration is available in context.Configuration
        // and is also automatically registered in the service collection.
        services.AddSingleton<IDummyService, DummyService>();
    }
}
