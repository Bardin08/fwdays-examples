using Microsoft.Extensions.DependencyInjection;

namespace Specifications.Commands;

public class CommandResolver(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public ICommand Resolve(int command)
    {
        return command switch
        {
            1 => _serviceProvider.GetRequiredService<PopulateDbCommand>(),
            2 => _serviceProvider.GetRequiredService<GetSampleDataCommand>(),
            3 => _serviceProvider.GetRequiredService<GetItemsCountCommand>(),
            4 => _serviceProvider.GetRequiredService<FilterRecordsCommand>(),
            5 => _serviceProvider.GetRequiredService<ExitCommand>(),
            _ => throw new ArgumentException("Invalid command")
        };
    }
}
