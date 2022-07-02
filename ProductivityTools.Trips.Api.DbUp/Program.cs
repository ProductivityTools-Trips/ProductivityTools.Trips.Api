// See https://aka.ms/new-console-template for more information
using DbUp;
using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using System.Reflection;

Console.WriteLine("Hello, World!");

IConfigurationRoot configuration = new ConfigurationBuilder()
.AddMasterConfiguration(configName: "ProductivityTools.Trips.Api.json", true)
.Build();


var connectionString =
      args.FirstOrDefault()
      ?? configuration["ConnectionString"];
EnsureDatabase.For.SqlDatabase(connectionString);

var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;
