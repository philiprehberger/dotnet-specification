using Xunit;
using Philiprehberger.Specification;

namespace Philiprehberger.Specification.Tests;

public class SpecificationEvaluatorTests
{
    [Fact]
    public void Evaluate_FiltersQueryable()
    {
        var data = new[] { -2, -1, 0, 1, 2, 3 }.AsQueryable();
        var spec = new IsPositiveSpec();

        var result = SpecificationEvaluator.Evaluate(data, spec).ToList();

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void Evaluate_EmptySource_ReturnsEmpty()
    {
        var data = Array.Empty<int>().AsQueryable();
        var spec = new IsPositiveSpec();

        var result = SpecificationEvaluator.Evaluate(data, spec).ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void Evaluate_NoMatches_ReturnsEmpty()
    {
        var data = new[] { -3, -2, -1 }.AsQueryable();
        var spec = new IsPositiveSpec();

        var result = SpecificationEvaluator.Evaluate(data, spec).ToList();

        Assert.Empty(result);
    }
}
