using System.Linq.Expressions;
using SpecDeck.Core;
using Specifications.Models;

namespace Specifications.Specs.DigitalItem;

public class DesignerSpecification(string designer)
    : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Designer.Equals(designer);
}
