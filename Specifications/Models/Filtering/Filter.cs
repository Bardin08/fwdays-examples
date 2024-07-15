namespace Specifications.Models.Filtering;

public class Filter
{
    public LogicalOperator Operator { get; set; }
    public List<FilterNode>? FilterNodes { get; set; }
}
