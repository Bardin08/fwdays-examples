using System.Linq.Expressions;
using SpecDeck.Core;
using Specifications.Models;

namespace Specifications.Specs.DigitalItem;

public class TypeSpecification(ItemType type) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Type == type;
}
