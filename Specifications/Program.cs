using Microsoft.Extensions.DependencyInjection;
using Specifications;
using Specifications.Commands;

using var scope = Startup.GetScope();

var commandResolver = scope.ServiceProvider.GetRequiredService<CommandResolver>();
string[] actions = [
    "1. Populate DB (with a fake data)",
    "2. Get sample data",
    "3. Get items count",
    "4. Filter items",
    "5. Exit"];

while (true)
{
    Console.WriteLine($"\nSelect an action:\n{string.Join(",\n", actions)}");

    Console.Write("Enter command number: ");
    var command = Console.ReadLine();
    var commandParsed = int.TryParse(command, out var commandNumber);
    if (!commandParsed)
    {
        Console.WriteLine("Invalid command");
        continue;
    }

    await commandResolver.Resolve(commandNumber).ExecuteAsync();
}
