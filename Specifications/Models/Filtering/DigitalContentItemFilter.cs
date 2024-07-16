using Specifications.Models.Filtering.Criteria;

namespace Specifications.Models.Filtering;

public class DigitalContentItemFilter : FilterNode
{
    public GuidFilterCriteria? Id { get; set; }
    public List<StringFilterCriteria>? Name { get; set; }
    public List<StringFilterCriteria>? Designer { get; set; }
    public List<NumericFilterCriteria>? Rating { get; set; }
    public List<EnumFilterCriteria<ItemFormat>>? Format { get; set; }
    public List<EnumFilterCriteria<ItemType>>? Type { get; set; }
}