using Xunit;
using Philiprehberger.Specification;

namespace Philiprehberger.Specification.Tests;

public class QueryableExtensionsTests
{
    [Fact]
    public void Where_WithSpecification_FiltersCorrectly()
    {
        var data = new[] { 1, 2, 3, 4, 5, 6 }.AsQueryable();
        var spec = new IsEvenSpec();

        var result = data.Where(spec).ToList();

        Assert.Equal(new[] { 2, 4, 6 }, result);
    }

    [Fact]
    public void Where_WithComposedSpecification_Works()
    {
        var data = new[] { -4, -1, 0, 2, 3, 6 }.AsQueryable();
        var spec = new IsPositiveSpec().And(new IsEvenSpec());

        var result = data.Where(spec).ToList();

        Assert.Equal(new[] { 2, 6 }, result);
    }

    [Fact]
    public void Where_AllMatch_ReturnsAll()
    {
        var data = new[] { 2, 4, 6 }.AsQueryable();
        var spec = new IsEvenSpec();

        var result = data.Where(spec).ToList();

        Assert.Equal(new[] { 2, 4, 6 }, result);
    }
}
