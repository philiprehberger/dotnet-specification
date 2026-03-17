# Philiprehberger.Specification

[![CI](https://github.com/philiprehberger/dotnet-specification/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-specification/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.Specification.svg)](https://www.nuget.org/packages/Philiprehberger.Specification)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-specification)](LICENSE)

Specification pattern implementation for composable, reusable query filters.

## Installation

```bash
dotnet add package Philiprehberger.Specification
```

## Usage

### Define Specifications

```csharp
using Philiprehberger.Specification;
using System.Linq.Expressions;

public class IsActive : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
        => user => user.IsActive;
}

public class HasMinimumAge : Specification<User>
{
    private readonly int _minimumAge;

    public HasMinimumAge(int minimumAge) => _minimumAge = minimumAge;

    public override Expression<Func<User, bool>> ToExpression()
        => user => user.Age >= _minimumAge;
}
```

### Compose Specifications

```csharp
var isActive = new IsActive();
var isAdult = new HasMinimumAge(18);

// Combine with And, Or, Not
var activeAdult = isActive.And(isAdult);
var inactiveOrMinor = isActive.Not().Or(isAdult.Not());
```

### Check Entities

```csharp
var spec = new IsActive().And(new HasMinimumAge(18));

bool satisfies = spec.IsSatisfiedBy(user);
```

### Filter Queryables

```csharp
var spec = new IsActive().And(new HasMinimumAge(18));

// Extension method
IQueryable<User> results = dbContext.Users.Where(spec);

// Or via evaluator
IQueryable<User> results = SpecificationEvaluator.Evaluate(dbContext.Users, spec);
```

### Implicit Conversion

```csharp
Expression<Func<User, bool>> expr = new IsActive();
var results = dbContext.Users.Where(expr);
```

## API

### `Specification<T>`

| Member | Description |
|--------|-------------|
| `ToExpression()` | Convert to a LINQ expression tree |
| `IsSatisfiedBy(T entity)` | Check if an entity satisfies the specification |
| `implicit operator Expression<Func<T, bool>>` | Implicit conversion to expression |

### `SpecificationExtensions`

| Method | Description |
|--------|-------------|
| `And<T>(Specification<T>, Specification<T>)` | Combine with logical AND |
| `Or<T>(Specification<T>, Specification<T>)` | Combine with logical OR |
| `Not<T>(Specification<T>)` | Negate with logical NOT |

### `QueryableExtensions`

| Method | Description |
|--------|-------------|
| `Where<T>(IQueryable<T>, Specification<T>)` | Filter a queryable using a specification |

### `SpecificationEvaluator`

| Method | Description |
|--------|-------------|
| `Evaluate<T>(IQueryable<T>, Specification<T>)` | Apply a specification to a queryable source |

## Development

```bash
dotnet build src/Philiprehberger.Specification.csproj --configuration Release
```

## License

MIT
