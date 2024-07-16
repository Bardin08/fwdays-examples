using Specifications.Models.Filtering.Criteria;

namespace Specifications.Models.Filtering.Fluent;

public class FilterBuilder
{
    private readonly Filter _filter;

    public FilterBuilder()
    {
        _filter = new Filter();
    }

    public FilterBuilder SetOperator(LogicalOperator op)
    {
        _filter.Operator = op;
        return this;
    }

    public FilterBuilder AddFilterNode(FilterNodeBuilder nodeBuilder)
    {
        if (_filter.FilterNodes == null)
        {
            _filter.FilterNodes = new List<FilterNode>();
        }

        _filter.FilterNodes.Add(nodeBuilder.Build());
        return this;
    }

    public Filter Build()
    {
        return _filter;
    }
}