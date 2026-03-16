using System.Linq.Expressions;

namespace Philiprehberger.Specification;

/// <summary>
/// Abstract base class for the specification pattern. Encapsulates a business rule
/// as a composable, reusable expression that can be evaluated in-memory or translated to a query.
/// </summary>
/// <typeparam name="T">The type of entity this specification applies to.</typeparam>
public abstract class Specification<T>
{
    /// <summary>
    /// Converts this specification to a LINQ expression tree.
    /// </summary>
    /// <returns>An expression representing the specification's predicate.</returns>
    public abstract Expression<Func<T, bool>> ToExpression();

    /// <summary>
    /// Evaluates whether the given entity satisfies this specification.
    /// </summary>
    /// <param name="entity">The entity to evaluate.</param>
    /// <returns><c>true</c> if the entity satisfies the specification; otherwise, <c>false</c>.</returns>
    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }

    /// <summary>
    /// Implicitly converts a specification to a LINQ expression.
    /// </summary>
    /// <param name="specification">The specification to convert.</param>
    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
    {
        return specification.ToExpression();
    }
}
