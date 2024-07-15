using SpecDeck.Core;
using Specifications.Models;

namespace Specifications.Specs.DigitalItem;

public static class DigitalItemsSpecs
{
    public static Specification<DigitalContentItem> IsImage()
        => TypeIs(ItemType.Image) &
           (FormatIs(ItemFormat.Png) | FormatIs(ItemFormat.Svg));

    public static Specification<DigitalContentItem> IsFont()
        => TypeIs(ItemType.Font) &
           FormatIs(ItemFormat.Otf);

    public static DesignerSpecification DesignerEquals(
        string designer) => new(designer);

    public static RatingLessOrGreaterThen RatingLessOrEqualsThen(
        double threshold) => new(threshold);

    public static RatingGreaterOrEqualsThen RatingGreaterOrEqualsThen(
        double threshold) => new(threshold);

    public static RatingGreaterThen RatingGreaterThen(
        double threshold) => new(threshold);

    public static RatingLessThen RatingLessThen(
        double threshold) => new(threshold);

    public static FormatSpecification FormatIs(
        ItemFormat format) => new(format);

    public static TypeSpecification TypeIs(
        ItemType type) => new(type);
}
