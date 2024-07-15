using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Specifications.Commands;
using Specifications.Persistence;

namespace Specifications;

public static class Startup
{
    public static IServiceScope GetScope()
    {
        IServiceScope? serviceScope = null;
        try
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql("Host=localhost;Database=specifications;Username=postgres;Password=123123"));

            serviceCollection.AddScoped<IDigitalContentRepository, DigitalContentRepository>();

            serviceCollection.AddTransient<CommandResolver>();

            serviceCollection.AddTransient<PopulateDbCommand>();
            serviceCollection.AddTransient<GetItemsCountCommand>();
            serviceCollection.AddTransient<GetSampleDataCommand>();
            serviceCollection.AddTransient<FilterRecordsCommand>();
            serviceCollection.AddTransient<ExitCommand>();

            var sp = serviceCollection.BuildServiceProvider();

            serviceScope = sp.CreateScope();
            return serviceScope;
        }
        catch
        {
            serviceScope?.Dispose();
            throw;
        }
    }
}
