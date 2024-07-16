using Specifications.Models.Filtering.Criteria;

namespace Specifications.Models.Filtering.Fluent;

public class GuidFilterCriteriaBuilder
{
    private GuidFilterCriteria _criteria = new();

    public GuidFilterCriteriaBuilder SetOperator(LogicalOperator op)
    {
        _criteria = _criteria with { Operator = op };
        return this;
    }

    public GuidFilterCriteriaBuilder SetOperation(GuidOperation op)
    {
        _criteria = _criteria with { Operation = op };
        return this;
    }

    public GuidFilterCriteriaBuilder SetValue(Guid value)
    {
        _criteria = _criteria with { Value = value };
        return this;
    }

    public GuidFilterCriteria Build()
    {
        return _criteria;
    }
}