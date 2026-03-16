namespace Philiprehberger.Specification;

/// <summary>
/// Extension methods for applying specifications to <see cref="IQueryable{T}"/> sources.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Filters an <see cref="IQueryable{T}"/> using the given specification.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <param name="source">The queryable source to filter.</param>
    /// <param name="specification">The specification to apply.</param>
    /// <returns>A filtered queryable containing only entities that satisfy the specification.</returns>
    public static IQueryable<T> Where<T>(this IQueryable<T> source, Specification<T> specification)
    {
        return source.Where(specification.ToExpression());
    }
}
