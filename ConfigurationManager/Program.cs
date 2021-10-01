using Microsoft.Extensions.Configuration;

const string testKey = "configuration";

var configuration = new ConfigurationManager();
Console.WriteLine(configuration[testKey]);

configuration.AddInMemoryCollection(new Dictionary<string, string>()
{
    { testKey, "configuration" }
});

Console.WriteLine(configuration[testKey]);
Console.ReadLine();
