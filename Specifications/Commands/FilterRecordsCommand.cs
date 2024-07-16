using Specifications.Models;
using Specifications.Models.Filtering;
using Specifications.Models.Filtering.Criteria;
using Specifications.Models.Filtering.Fluent;
using Specifications.Persistence;
using Specifications.Specs;

namespace Specifications.Commands;

public class FilterRecordsCommand(IDigitalContentRepository repository) : ICommand
{
    private readonly IDigitalContentRepository _repository = repository;

    public async Task ExecuteAsync()
    {
        var filter = new FilterBuilder()
            .SetOperator(LogicalOperator.Or)
            .AddFilterNode(new DigitalContentItemFilterBuilder()
                .AddName(n => n
                    .SetOperator(LogicalOperator.And)
                    .SetOperation(StringOperation.ContainsAny)
                    .SetValues(["Font", "Designer", "Image"])
                )
                .AddName(n => n
                    .SetOperator(LogicalOperator.And)
                    .SetOperation(StringOperation.ContainsNone)
                    .SetValues(["Web", "Associate"])
                )
                .AddRating(r => r
                    .SetOperation(NumericOperation.GreaterThan)
                    .SetValue(4.1)
                )
            )
            .AddFilterNode(new DigitalContentItemFilterBuilder()
                .AddRating(r => r
                    .SetOperation(NumericOperation.LessThan)
                    .SetValue(0.1)
                )
            )
            .Build();

        var specMapper = new DigitalContentItemFilterFilterMapper();
        var spec = specMapper.GetSpec(filter);

        var specContext = new EfSpecContext<DigitalContentItem>
        {
            FilterSpec = spec,
            From = 0,
            PageSize = 10,
            Includes =
            [
                x => x.Rating
            ]
        };

        var filtered = _repository.ListPaginatedAsync(specContext);
        await foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
    }
}
