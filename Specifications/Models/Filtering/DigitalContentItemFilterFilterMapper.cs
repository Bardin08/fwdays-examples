using SpecDeck.Core;
using Specifications.Models.Specs.DigitalContentItem;
using Specifications.Specs.DigitalItem;

namespace Specifications.Models.Filtering;

public class DigitalContentItemFilterFilterMapper : BaseFilterMapper<DigitalContentItem>
{
    public DigitalContentItemFilterFilterMapper()
    {
        SpecMapping.Add(
            nameof(DigitalContentItemFilter.Name),
            criteria => GetStringSpec(
                (StringFilterCriteria)criteria,
                DigitalContentItemSpecs.NameContainsSpec,
                DigitalContentItemSpecs.NameStartsWithSpec,
                DigitalContentItemSpecs.NameEndsWithSpec,
                DigitalContentItemSpecs.NameEqualsSpec
            )
        );

        SpecMapping.Add(
            nameof(DigitalContentItemFilter.Designer),
            criteria => GetStringSpec(
                (StringFilterCriteria)criteria,
                DigitalContentItemSpecs.DesignerContainsSpec,
                DigitalContentItemSpecs.DesignerStartsWithSpec,
                DigitalContentItemSpecs.DesignerEndsWithSpec,
                DigitalContentItemSpecs.DesignerEqualsSpec
            )
        );

        SpecMapping.Add(
            nameof(DigitalContentItemFilter.Rating),
            criteria => GetNumericSpec(
                (NumericFilterCriteria)criteria,
                DigitalItemsSpecs.RatingGreaterThen,
                DigitalItemsSpecs.RatingGreaterOrEqualsThen,
                DigitalItemsSpecs.RatingLessThen,
                DigitalItemsSpecs.RatingLessOrEqualsThen
            )
        );

        SpecMapping.Add(
            nameof(DigitalContentItemFilter.Format),
            criteria => GetEnumSpec(
                (EnumFilterCriteria<ItemFormat>)criteria,
                DigitalContentItemSpecs.FormatEqualsSpec
            )
        );

        SpecMapping.Add(
            nameof(DigitalContentItemFilter.Type),
            criteria => GetEnumSpec(
                (EnumFilterCriteria<ItemType>)criteria,
                DigitalContentItemSpecs.TypeEqualsSpec
            )
        );
    }

    protected override Specification<DigitalContentItem> MapGroup(
        FilterNode node,
        LogicalOperator parentOperator)
    {
        if (node is not DigitalContentItemFilter filter)
            throw new ArgumentException("FilterNode must be of type DigitalContentItemFilter");

        var specs = new List<(LogicalOperator, Specification<DigitalContentItem>)>();

        if (filter.Name?.Count > 0)
            specs.AddRange(AddSpecs(nameof(DigitalContentItemFilter.Name), filter.Name, node.Operator));

        if (filter.Designer?.Count > 0)
            specs.AddRange(AddSpecs(nameof(DigitalContentItemFilter.Designer), filter.Designer, node.Operator));

        if (filter.Rating?.Count > 0)
            specs.AddRange(AddSpecs(nameof(DigitalContentItemFilter.Rating), filter.Rating, node.Operator));

        if (filter.Format?.Count > 0)
            specs.AddRange(AddSpecs(nameof(DigitalContentItemFilter.Format), filter.Format, node.Operator));

        if (filter.Type?.Count > 0)
            specs.AddRange(AddSpecs(nameof(DigitalContentItemFilter.Type), filter.Type, node.Operator));

        return AggregateSpecs(specs);
    }
}
