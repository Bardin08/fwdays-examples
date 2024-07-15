using SpecDeck.Core;
using Specifications.Models;
using Specifications.Persistence;
using Specifications.Specs;

namespace Specifications.Commands;

public class GetItemsCountCommand(IDigitalContentRepository repository) : ICommand
{
    private readonly IDigitalContentRepository _repository = repository;

    public async Task ExecuteAsync()
    {
        var count = await _repository.CountAsync(new EfSpecContext<DigitalContentItem>()
        {
            FilterSpec = Specification<DigitalContentItem>.True
        });

        Console.WriteLine($"Total records: {count}");
    }
}