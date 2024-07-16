namespace Specifications.Models.Filtering.Criteria;

public record NumericFilterCriteria : IFilterCriteria
{
    public LogicalOperator Operator { get; init; }
    public NumericOperation Operation { get; init; }
    public double Value { get; init; }
}