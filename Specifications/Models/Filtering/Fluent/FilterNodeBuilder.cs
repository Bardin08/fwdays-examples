using Specifications.Models.Filtering.Criteria;

namespace Specifications.Models.Filtering.Fluent;

public class FilterNodeBuilder
{
    protected readonly FilterNode Node = new();

    public FilterNodeBuilder SetOperator(LogicalOperator op)
    {
        Node.Operator = op;
        return this;
    }

    public virtual FilterNode Build()
    {
        return Node;
    }
}