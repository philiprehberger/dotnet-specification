using Xunit;
using Philiprehberger.Specification;

namespace Philiprehberger.Specification.Tests;

public class SpecificationExtensionsTests
{
    [Fact]
    public void And_BothSatisfied_ReturnsTrue()
    {
        var positive = new IsPositiveSpec();
        var even = new IsEvenSpec();

        var combined = positive.And(even);

        Assert.True(combined.IsSatisfiedBy(4));
    }

    [Fact]
    public void And_OnlyOneSatisfied_ReturnsFalse()
    {
        var positive = new IsPositiveSpec();
        var even = new IsEvenSpec();

        var combined = positive.And(even);

        Assert.False(combined.IsSatisfiedBy(3));
    }

    [Fact]
    public void Or_EitherSatisfied_ReturnsTrue()
    {
        var positive = new IsPositiveSpec();
        var even = new IsEvenSpec();

        var combined = positive.Or(even);

        Assert.True(combined.IsSatisfiedBy(3));
        Assert.True(combined.IsSatisfiedBy(-2));
    }

    [Fact]
    public void Or_NeitherSatisfied_ReturnsFalse()
    {
        var positive = new IsPositiveSpec();
        var even = new IsEvenSpec();

        var combined = positive.Or(even);

        Assert.False(combined.IsSatisfiedBy(-3));
    }

    [Fact]
    public void Not_Negates_Specification()
    {
        var positive = new IsPositiveSpec();

        var negated = positive.Not();

        Assert.True(negated.IsSatisfiedBy(-1));
        Assert.False(negated.IsSatisfiedBy(1));
    }
}
