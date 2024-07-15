namespace Specifications.Models.Filtering.Fluent;

public class StringFilterCriteriaBuilder
{
    private StringFilterCriteria _criteria = new();

    public StringFilterCriteriaBuilder SetOperator(LogicalOperator op)
    {
        _criteria = _criteria with { Operator = op };
        return this;
    }

    public StringFilterCriteriaBuilder SetOperation(StringOperation op)
    {
        _criteria = _criteria with { Operation = op };
        return this;
    }

    public StringFilterCriteriaBuilder SetValues(List<string> values)
    {
        _criteria = _criteria with { Values = values };
        return this;
    }

    public StringFilterCriteria Build()
    {
        return _criteria;
    }
}