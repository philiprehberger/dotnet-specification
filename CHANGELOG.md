# Changelog

## 0.1.6 (2026-03-24)

- Add unit tests
- Add test step to CI workflow

## 0.1.5 (2026-03-24)

- Sync .csproj description with README

## 0.1.4 (2026-03-22)

- Add dates to changelog entries

## 0.1.3 (2026-03-17)

- Rename Install section to Installation in README per package guide

## 0.1.2 (2026-03-16)

- Add Development section to README
- Add GenerateDocumentationFile, RepositoryType, PackageReadmeFile to .csproj

## 0.1.0 (2026-03-15)

- Initial release
- Abstract `Specification<T>` base class with expression tree support
- Composable operators: `And`, `Or`, `Not`
- `IQueryable<T>` integration via `Where` extension method
- `SpecificationEvaluator` for explicit query filtering
- Implicit conversion from specification to `Expression<Func<T, bool>>`
