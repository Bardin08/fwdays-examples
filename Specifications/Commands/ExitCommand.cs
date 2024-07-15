namespace Specifications.Commands;

public class ExitCommand : ICommand
{
    public Task ExecuteAsync()
    {
        Environment.Exit(0);
        return Task.CompletedTask;
    }
}