using Bardin08.ProgressBar;
using Bogus;
using Specifications.Models;
using Specifications.Persistence;

namespace Specifications.Commands;

public class PopulateDbCommand(ApplicationDbContext dbContext) : ICommand
{
    private static readonly Faker<DigitalContentItem> Faker = new Faker<DigitalContentItem>()
        .RuleFor(x => x.Name, f => f.Name.JobTitle())
        .RuleFor(x => x.Designer, f => f.Person.FullName)
        .RuleFor(x => x.Format, f => f.PickRandom<ItemFormat>())
        .RuleFor(x => x.Type, f => f.PickRandom<ItemType>())
        .RuleFor(x => x.Rating, f => RatingFaker.Generate(f.Random.Number(1, 20)));

    private static readonly Faker<Rating> RatingFaker = new Faker<Rating>()
        .RuleFor(x => x.Mark, f => f.Random.Double(0, 5));

    private const int DbSize = 100_000;
    private const int BatchSize = 1_000;
    private const int Batches = DbSize / BatchSize;

    private readonly ProgressBar _progressBar = new(DbSize, new ProgressBarOptions
    {
        Prefix = "Items generated:"
    });
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task ExecuteAsync()
    {
        for (var i = 0; i < Batches; i++)
        {
            var items = Faker.Generate(BatchSize);
            _dbContext.DigitalItems.AddRange(items);
            await _dbContext.SaveChangesAsync();

            _progressBar.Update(BatchSize);
        }
    }
}
