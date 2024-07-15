namespace Specifications.Models.Filtering.Fluent;

public class NumericFilterCriteriaBuilder
{
    private NumericFilterCriteria _criteria;

    public NumericFilterCriteriaBuilder()
    {
        _criteria = new NumericFilterCriteria();
    }

    public NumericFilterCriteriaBuilder SetOperator(LogicalOperator op)
    {
        _criteria = _criteria with { Operator = op };
        return this;
    }

    public NumericFilterCriteriaBuilder SetOperation(NumericOperation op)
    {
        _criteria = _criteria with { Operation = op };
        return this;
    }

    public NumericFilterCriteriaBuilder SetValue(double value)
    {
        _criteria = _criteria with { Value = value };
        return this;
    }

    public NumericFilterCriteria Build()
    {
        return _criteria;
    }
}