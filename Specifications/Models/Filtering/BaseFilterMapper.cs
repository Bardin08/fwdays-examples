using SpecDeck.Core;
using Specifications.Models.Filtering.Criteria;

namespace Specifications.Models.Filtering;

public abstract class BaseFilterMapper<TModel>
{
    protected readonly Dictionary<string, Func<IFilterCriteria, Specification<TModel>?>> SpecMapping = new();

    public Specification<TModel> GetSpec(Filter filter)
    {
        if (filter.FilterNodes == null)
            return Specification<TModel>.True;

        var specs = filter.FilterNodes
            .Select(node => MapGroup(node, filter.Operator))
            .Select(spec => (filter.Operator, spec))
            .ToList();

        return AggregateSpecs(specs);
    }

    protected abstract Specification<TModel> MapGroup(
        FilterNode node,
        LogicalOperator parentOperator);

    protected List<(LogicalOperator op, Specification<TModel> spec)> AddSpecs<T>(
        string key,
        List<T> criteriaList,
        LogicalOperator nodeOperator)
        where T : IFilterCriteria
    {
        return criteriaList
            .Select(c => new { criteria = c, mappingFunc = SpecMapping[key] })
            .Select(t => t.mappingFunc(t.criteria))
            .Where(t => t != null!)
            .Select(spec => (nodeOperator, spec)).ToList()!;
    }

    protected Specification<TModel>? GetStringSpec(StringFilterCriteria criteria,
        Func<string, Specification<TModel>> containsSpec,
        Func<string, Specification<TModel>> startsWithSpec,
        Func<string, Specification<TModel>> endsWithSpec,
        Func<string, Specification<TModel>> equalsSpec)
    {
        if (criteria.Values == null || criteria.Values.Count == 0)
            return null;

        return criteria.Operation switch
        {
            StringOperation.ContainsAll => criteria.Values.Select(containsSpec).CombineAnd(),
            StringOperation.ContainsAny => criteria.Values.Select(containsSpec).CombineOr(),
            StringOperation.ContainsNone => !criteria.Values.Select(containsSpec).CombineAnd(),
            StringOperation.StartsWith => criteria.Values.Select(startsWithSpec).CombineAnd(),
            StringOperation.StartsWithAny => criteria.Values.Select(startsWithSpec).CombineOr(),
            StringOperation.StartsWithNone => !criteria.Values.Select(startsWithSpec).CombineAnd(),
            StringOperation.EndsWith => criteria.Values.Select(endsWithSpec).CombineAnd(),
            StringOperation.EndsWithAny => criteria.Values.Select(endsWithSpec).CombineOr(),
            StringOperation.EndsWithNone => !criteria.Values.Select(endsWithSpec).CombineAnd(),
            StringOperation.EqualsAny => criteria.Values.Select(equalsSpec).CombineOr(),
            StringOperation.NotEquals => !criteria.Values.Select(equalsSpec).CombineAnd(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected Specification<TModel> GetNumericSpec(
        NumericFilterCriteria criteria,
        Func<double, Specification<TModel>> greaterThanSpec,
        Func<double, Specification<TModel>> greaterThanOrEqualsSpec,
        Func<double, Specification<TModel>> lessThanSpec,
        Func<double, Specification<TModel>> lessThanOrEqualsSpec)
    {
        return criteria.Operation switch
        {
            NumericOperation.GreaterThan => greaterThanSpec(criteria.Value),
            NumericOperation.GreaterThanOrEquals => greaterThanOrEqualsSpec(criteria.Value),
            NumericOperation.LessThan => lessThanSpec(criteria.Value),
            NumericOperation.LessThanOrEquals => lessThanOrEqualsSpec(criteria.Value),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected Specification<TModel>? GetEnumSpec<TEnum>(
        EnumFilterCriteria<TEnum> criteria,
        Func<TEnum, Specification<TModel>> equalsSpec)
    {
        if (criteria.Values == null || criteria.Values.Count == 0)
            return null;

        return criteria.Operation switch
        {
            EnumOperation.EqualsAny => criteria.Values.Select(equalsSpec).CombineAnd(),
            EnumOperation.NotEquals => !criteria.Values.Select(equalsSpec).CombineAnd(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected Specification<TModel> AggregateSpecs(
        List<(LogicalOperator, Specification<TModel>)> specs)
    {
        var aggregated = specs.Aggregate((acc, next) => next.Item1 switch
        {
            LogicalOperator.And => (next.Item1, acc.Item2 & next.Item2),
            LogicalOperator.Or => (next.Item1, acc.Item2 | next.Item2),
            LogicalOperator.Not => (next.Item1, acc.Item2 & !next.Item2),
            _ => throw new ArgumentOutOfRangeException()
        });

        return aggregated.Item2;
    }
}
