using Microsoft.EntityFrameworkCore;
using Specifications.Specs;

namespace Specifications.Persistence;

public class SpecRepository<TEntity, TContext>(TContext dbContext) : ISpecRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    public Task<int> CountAsync(EfSpecContext<TEntity> spec) =>
        dbContext.Set<TEntity>().CountAsync(spec.FilterSpec.ToExpression());

    public IAsyncEnumerable<TEntity> ListPaginatedAsync(EfSpecContext<TEntity> ctx)
    {
        var query = dbContext
            .Set<TEntity>()
            .Where(ctx.FilterSpec.ToExpression())
            .Skip(ctx.From)
            .Take(ctx.PageSize);

        if (ctx.Includes != null)
            query = ctx.Includes.Aggregate(
                query,
                (current, include) => current.Include(include)
            );

        return query.AsAsyncEnumerable();
    }
}
