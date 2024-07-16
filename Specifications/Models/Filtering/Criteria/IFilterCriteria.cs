namespace Specifications.Models.Filtering.Criteria;

public interface IFilterCriteria
{
    LogicalOperator Operator { get; }
}