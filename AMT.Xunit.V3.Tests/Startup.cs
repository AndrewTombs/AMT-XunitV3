using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AMT.Xunit.V3.Tests;

public class Startup
{
    public void ConfigureHost(IHostBuilder hostBuilder) =>
        hostBuilder.ConfigureAppConfiguration(builder =>
        {
            builder.AddJsonFile("appsettings.json");
        });

    public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
    {
        // The IConfiguration is available in context.Configuration
        // and is also automatically registered in the service collection.
        services.AddSingleton<IDummyService, DummyService>();
    }
}
