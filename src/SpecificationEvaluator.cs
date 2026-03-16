namespace Philiprehberger.Specification;

/// <summary>
/// Evaluates specifications against queryable data sources.
/// </summary>
public static class SpecificationEvaluator
{
    /// <summary>
    /// Applies a specification to a queryable source, returning only matching entities.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <param name="query">The queryable source to filter.</param>
    /// <param name="spec">The specification to evaluate.</param>
    /// <returns>A filtered queryable containing only entities that satisfy the specification.</returns>
    public static IQueryable<T> Evaluate<T>(IQueryable<T> query, Specification<T> spec)
    {
        return query.Where(spec.ToExpression());
    }
}
