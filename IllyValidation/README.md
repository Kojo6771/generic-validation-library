# ILLY Validation Technical Test

## Overview

This project is a small generic validation library written in C#.

The aim is to validate loosely structured or nullable input data and, when the validation succeeds, convert it into a stricter validated type.

The project also demonstrates how multiple validation rules can be combined together while collecting all validation errors rather than stopping at the first failure.

## Project Structure

The solution contains two projects:

### ValidationLibrary

Contains the reusable validation functionality.

Key components include:

- `ValidationResult<TSuccess, TError>` - represents either a successful validation result or a list of validation errors.
- `Success<TSuccess, TError>` - contains the successfully validated value.
- `Error<TSuccess, TError>` - contains one or more validation errors.
- `Validator<TInput, TOutput, TError>` - provides a generic way of defining validation routines.
- `Rules` - contains reusable validation rules.
- `Validation.Combine` - combines multiple validation results and accumulates errors.
- `Map` and `Bind` - allow validation operations to be chained together.

### ValidationDemo

Contains an example implementation using a `PersonInput` object.

The example validates:

- Name must be entered.
- Name must not exceed the maximum length.
- Date of birth must be entered.
- Date of birth cannot be in the future.
- Date of birth cannot be before 1905.
- Borough is optional.

If validation succeeds, the `PersonInput` is converted into a `ValidPerson`.

## Example

An input object may contain nullable properties:

```csharp
public sealed record PersonInput(
    string? Name,
    DateTime? DOB,
    int? Borough
);
```

After successful validation, it is converted into a stricter type:

```csharp
public sealed record ValidPerson(
    string Name,
    DateTime DOB,
    int? Borough
);
```

This means required fields such as `Name` and `DOB` are guaranteed to contain valid values once a `ValidPerson` has been created.

## Validation Results

A validation returns either a successful value:

```text
Success
    ValidPerson
```

or a list of validation errors:

```text
Error
    NameMustBeEntered
    DOBCannotBeInFuture
```

Multiple validation failures are collected together so that the caller can see all problems with the input at once.

## Reusable Validation Rules

The library includes reusable rules for common validation scenarios, including:

- Required text
- Required nullable values
- Maximum string length
- Dates that cannot be in the future
- Minimum allowed dates

These rules are generic and are not tied specifically to the `Person` example, allowing them to be reused for other types such as appointments, orders or other business objects.

## Requirements

- .NET 10 SDK
- C#

Check your installed .NET version with:

```bash
dotnet --version
```

## Running the Project

From the root `IllyValidation` directory, build the solution:

```bash
dotnet build
```

Then run the example console application:

```bash
dotnet run --project ./ValidationDemo/ValidationDemo.csproj
```

## Example Output

Example successful validation:

```text
VALID
Name: Kojo
DOB: 20/05/2000
Borough: 1
```

Example failed validation:

```text
INVALID
- NameMustBeEntered
- DOBCannotBeInFuture
```

## Design Decisions

### Generic Validation

The core validation library does not depend on the `Person` type.

The generic validator is defined using:

```csharp
Validator<TInput, TOutput, TError>
```

This allows the same validation infrastructure to be reused with different input, output and error types.

### Error Accumulation

Validation routines for separate properties are evaluated independently and their errors are combined.

This allows an input containing several invalid fields to return all relevant errors in a single validation result.

### Strongly Typed Errors

The example uses an enum for validation errors rather than plain strings:

```csharp
public enum PersonValidation
{
    NameMustBeEntered,
    NameMaximumLengthExceeded,
    DOBMustBeEntered,
    DOBCannotBeInFuture,
    DOBCannotBeBefore1905
}
```

This makes validation errors easier to work with and reduces reliance on string comparisons.

### Nullable Input to Validated Output

The input type allows nullable values because user-entered data may be incomplete.

The validated output makes required fields non-nullable, meaning that once validation succeeds the rest of the application can safely work with the validated object.

## Possible Future Improvements

Some possible extensions to the validation library include:

- Support for warnings as well as errors.
- Additional reusable validation rules.
- Unit tests for the validation library.
- More flexible methods for combining larger numbers of validation results.
- Additional example domain types.

## Author

Created as part of the ILLY Systems development technical scenario.
