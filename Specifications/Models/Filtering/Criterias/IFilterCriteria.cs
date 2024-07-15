namespace Specifications.Models.Filtering;

public interface IFilterCriteria
{
    LogicalOperator Operator { get; }
}