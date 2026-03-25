using Xunit;
using System.Linq.Expressions;
using Philiprehberger.Specification;

namespace Philiprehberger.Specification.Tests;

public class IsPositiveSpec : Specification<int>
{
    public override Expression<Func<int, bool>> ToExpression() => x => x > 0;
}

public class IsEvenSpec : Specification<int>
{
    public override Expression<Func<int, bool>> ToExpression() => x => x % 2 == 0;
}

public class SpecificationTests
{
    [Theory]
    [InlineData(5, true)]
    [InlineData(0, false)]
    [InlineData(-3, false)]
    public void IsSatisfiedBy_EvaluatesCorrectly(int value, bool expected)
    {
        var spec = new IsPositiveSpec();

        Assert.Equal(expected, spec.IsSatisfiedBy(value));
    }

    [Fact]
    public void ToExpression_ReturnsValidExpression()
    {
        var spec = new IsPositiveSpec();

        Expression<Func<int, bool>> expr = spec.ToExpression();

        Assert.NotNull(expr);
        Assert.True(expr.Compile()(1));
    }

    [Fact]
    public void ImplicitConversion_ToExpression_Works()
    {
        var spec = new IsPositiveSpec();

        Expression<Func<int, bool>> expr = spec;

        Assert.NotNull(expr);
        Assert.True(expr.Compile()(10));
    }
}
