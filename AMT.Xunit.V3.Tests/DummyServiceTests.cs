using Microsoft.Extensions.Configuration;
using Xunit;

namespace AMT.Xunit.V3.Tests;

public class DummyServiceTests
{
    private readonly IDummyService _dummyService;
    private readonly IConfiguration _configuration;

    public DummyServiceTests(IDummyService dummyService, IConfiguration configuration)
    {
        _dummyService = dummyService;
        _configuration = configuration;
    }

    [Fact]
    public void GetGreeting_ShouldReturn_CorrectGreeting()
    {
        // Arrange
        var name = "World";
        var expectedGreeting = "Hello, World!";

        // Act
        var result = _dummyService.GetGreeting(name);

        // Assert
        Assert.Equal(expectedGreeting, result);
    }

    [Fact]
    public void Can_Read_AppName_From_Configuration()
    {
        // Arrange
        var expectedAppName = "My xUnit Test App";

        // Act
        var appName = _configuration["MySettings:AppName"];

        // Assert
        Assert.Equal(expectedAppName, appName);
    }
}
