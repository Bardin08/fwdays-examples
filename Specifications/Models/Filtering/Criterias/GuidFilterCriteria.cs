namespace Specifications.Models.Filtering;

public record GuidFilterCriteria : IFilterCriteria
{
    public LogicalOperator Operator { get; init; }
    public GuidOperation Operation { get; init; }
    public Guid Value { get; init; }
}
