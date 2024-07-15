using Specifications.Specs;

namespace Specifications.Persistence;

public interface ISpecRepository<TEntity>
{
    Task<int> CountAsync(EfSpecContext<TEntity> spec);
    IAsyncEnumerable<TEntity> ListPaginatedAsync(EfSpecContext<TEntity> ctx);
}