namespace Specifications.Models.Filtering;

public record EnumFilterCriteria<T> : IFilterCriteria
{
    public LogicalOperator Operator { get; init; }
    public EnumOperation Operation { get; init; }
    public List<T>? Values { get; init; }
}