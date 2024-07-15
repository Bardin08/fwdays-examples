namespace Specifications.Models.Filtering;

public record StringFilterCriteria : IFilterCriteria
{
    public LogicalOperator Operator { get; init; }
    public StringOperation Operation { get; init; }
    public List<string>? Values { get; init; }
}
