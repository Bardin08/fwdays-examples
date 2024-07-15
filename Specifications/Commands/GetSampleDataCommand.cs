using Specifications.Models;
using Specifications.Persistence;
using Specifications.Specs;
using Specifications.Specs.DigitalItem;

namespace Specifications.Commands;

public class GetSampleDataCommand(IDigitalContentRepository repository) : ICommand
{
    private readonly IDigitalContentRepository _repository = repository;

    public async Task ExecuteAsync()
    {
        var imageOrFontWithRating =
            (
                DigitalItemsSpecs.IsImage() |
                DigitalItemsSpecs.IsFont()
            ) &
            DigitalItemsSpecs.RatingGreaterOrEqualsThen(4.5);

        var specContext = new EfSpecContext<DigitalContentItem>
        {
            FilterSpec = imageOrFontWithRating,
            From = 0,
            PageSize = 10
        };

        var filtered = _repository.ListPaginatedAsync(specContext);
        await foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
    }
}
