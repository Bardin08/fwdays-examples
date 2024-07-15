namespace Specifications.Models.Filtering.Fluent;

public class DigitalContentItemFilterBuilder : FilterNodeBuilder
{
    private readonly DigitalContentItemFilter _itemFilter = new();

    public DigitalContentItemFilterBuilder SetId(Action<GuidFilterCriteriaBuilder> builderAction)
    {
        var builder = new GuidFilterCriteriaBuilder();
        builderAction(builder);
        _itemFilter.Id = builder.Build();
        return this;
    }

    public DigitalContentItemFilterBuilder AddName(Action<StringFilterCriteriaBuilder> builderAction)
    {
        var builder = new StringFilterCriteriaBuilder();
        builderAction(builder);
        if (_itemFilter.Name == null)
        {
            _itemFilter.Name = new List<StringFilterCriteria>();
        }

        _itemFilter.Name.Add(builder.Build());
        return this;
    }

    public DigitalContentItemFilterBuilder AddDesigner(Action<StringFilterCriteriaBuilder> builderAction)
    {
        var builder = new StringFilterCriteriaBuilder();
        builderAction(builder);
        if (_itemFilter.Designer == null)
        {
            _itemFilter.Designer = new List<StringFilterCriteria>();
        }

        _itemFilter.Designer.Add(builder.Build());
        return this;
    }

    public DigitalContentItemFilterBuilder AddRating(Action<NumericFilterCriteriaBuilder> builderAction)
    {
        var builder = new NumericFilterCriteriaBuilder();
        builderAction(builder);
        if (_itemFilter.Rating == null)
        {
            _itemFilter.Rating = new List<NumericFilterCriteria>();
        }

        _itemFilter.Rating.Add(builder.Build());
        return this;
    }

    public DigitalContentItemFilterBuilder AddFormat(Action<EnumFilterCriteriaBuilder<ItemFormat>> builderAction)
    {
        var builder = new EnumFilterCriteriaBuilder<ItemFormat>();
        builderAction(builder);
        if (_itemFilter.Format == null)
        {
            _itemFilter.Format = new List<EnumFilterCriteria<ItemFormat>>();
        }

        _itemFilter.Format.Add(builder.Build());
        return this;
    }

    public DigitalContentItemFilterBuilder AddType(Action<EnumFilterCriteriaBuilder<ItemType>> builderAction)
    {
        var builder = new EnumFilterCriteriaBuilder<ItemType>();
        builderAction(builder);
        _itemFilter.Type ??= [];

        _itemFilter.Type.Add(builder.Build());
        return this;
    }

    public override FilterNode Build()
    {
        return _itemFilter;
    }
}