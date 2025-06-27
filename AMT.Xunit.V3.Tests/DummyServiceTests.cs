using System;
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
    [Trait("Category", "Smoke")]
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
    [Trait("Category", "Smoke")]
    public void Can_Read_AppName_From_Configuration()
    {
        // Arrange
        var expectedAppName = "My xUnit Test App";

        // Act
        var appName = _configuration["MySettings:AppName"];

        // Assert
        Assert.Equal(expectedAppName, appName);
    }

    [Fact]
    [Trait("Category", "Regression")]
    public void This_Is_A_Failing_Test()
    {
        // Assert
        Assert.True(false, "This test is designed to fail.");
    }

    [Fact]
    [Trait("Category", "Regression")]
    public void Can_Read_Api_Timeout_From_Configuration()
    {
        // Arrange
        var expectedTimeout = "30";

        // Act
        var timeout = _configuration["MySettings:Api:TimeoutSeconds"];

        // Assert
        Assert.Equal(expectedTimeout, timeout);
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void Can_Read_Environment_Variables_From_Configuration()
    {
        // Arrange
        var environmentSecret = _configuration["XUNIT:ENVIRONMENTSECRET"];
        var environmentUrl = _configuration["XUNIT:ENVIRONMENTURL"];

        // Act & Assert
        Assert.False(string.IsNullOrEmpty(environmentSecret), "EnvironmentSecret should not be null or empty");
        Assert.False(string.IsNullOrEmpty(environmentUrl), "EnvironmentUrl should not be null or empty");

        Console.WriteLine($"EnvironmentSecret: {environmentSecret}");
        Console.WriteLine($"EnvironmentUrl: {environmentUrl}");
    }

    [Fact]
    [Trait("Category", "Smoke")]
    public void Print_All_Configuration_Values()
    {
        var allConfiguration = _configuration.AsEnumerable();

        foreach (var (key, value) in allConfiguration)
        {
            Console.WriteLine($"{key}: {value}");
        }
    }
}
