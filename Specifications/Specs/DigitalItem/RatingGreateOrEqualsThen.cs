using System.Linq.Expressions;
using SpecDeck.Core;
using Specifications.Models;

namespace Specifications.Specs.DigitalItem;

public class RatingGreaterOrEqualsThen(double threshold) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Rating!.Average(x => x.Mark) >= threshold;
}

public class RatingGreaterThen(double threshold) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Rating!.Average(x => x.Mark) > threshold;
}


public class RatingLessOrGreaterThen(double threshold) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Rating!.Average(x => x.Mark) >= threshold;
}

public class RatingLessThen(double threshold) : Specification<DigitalContentItem>
{
    public override Expression<Func<DigitalContentItem, bool>> ToExpression()
        => e => e.Rating!.Average(x => x.Mark) < threshold;
}
