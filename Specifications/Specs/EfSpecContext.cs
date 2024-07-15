using System.Linq.Expressions;
using SpecDeck.Core;

namespace Specifications.Specs;

public class EfSpecContext<TEntity>
{
    public required Specification<TEntity> FilterSpec { get; set; }
    public List<Expression<Func<TEntity, object>>>? Includes { get; set; }
    public int From { get; set; }
    public int PageSize { get; set; }
}
