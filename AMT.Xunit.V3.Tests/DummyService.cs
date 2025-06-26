namespace AMT.Xunit.V3.Tests;

public class DummyService : IDummyService
{
    public string GetGreeting(string name)
    {
        return $"Hello, {name}!";
    }
}
