# Changelog

## 0.1.0 (2026-03-15)

- Initial release
- Abstract `Specification<T>` base class with expression tree support
- Composable operators: `And`, `Or`, `Not`
- `IQueryable<T>` integration via `Where` extension method
- `SpecificationEvaluator` for explicit query filtering
- Implicit conversion from specification to `Expression<Func<T, bool>>`
