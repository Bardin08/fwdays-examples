using System.Linq.Expressions;
using SpecDeck.Core;
using Specifications.Models;

namespace Specifications.Specs.DigitalItem;

public class FormatSpecification(ItemFormat format) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Format == format;
}