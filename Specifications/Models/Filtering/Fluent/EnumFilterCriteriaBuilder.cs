namespace Specifications.Models.Filtering.Fluent;

public class EnumFilterCriteriaBuilder<T>
{
    private EnumFilterCriteria<T> _criteria = new();

    public EnumFilterCriteriaBuilder<T> SetOperator(LogicalOperator op)
    {
        _criteria = _criteria with { Operator = op };
        return this;
    }

    public EnumFilterCriteriaBuilder<T> SetOperation(EnumOperation op)
    {
        _criteria = _criteria with { Operation = op };
        return this;
    }

    public EnumFilterCriteriaBuilder<T> SetValues(List<T> values)
    {
        _criteria = _criteria with { Values = values };
        return this;
    }

    public EnumFilterCriteria<T> Build()
    {
        return _criteria;
    }
}