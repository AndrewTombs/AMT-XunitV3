using Microsoft.Extensions.DependencyInjection;

namespace AMT.Xunit.V3.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDummyService, DummyService>();
    }
}
