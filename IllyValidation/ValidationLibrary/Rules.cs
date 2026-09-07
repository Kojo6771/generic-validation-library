namespace ValidationLibrary;

public static class Rules
{
    // Validates that a string is not null, empty, or whitespace.
    public static ValidationResult<string, TError> RequiredText<TError>(
        string? value,
        TError error)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Validation.Failure<string, TError>(
                error
            );
        }

        return Validation.Success<string, TError>(
            value
        );
    }

    // Validates that a value is present (not null for reference types or has a value for nullable value types).
    public static ValidationResult<T, TError> RequiredValue<T, TError>(
        T? value,
        TError error)
        where T : struct
    {
        if (!value.HasValue)
        {
            return Validation.Failure<T, TError>(
                error
            );
        }

        return Validation.Success<T, TError>(
            value.Value
        );
    }
    // Validates that the length of a string does not exceed the specified maximum length.
    public static ValidationResult<string, TError> MaxLength<TError>(
        string value,
        int maximumLength,
        TError error)
    {
        if (value.Length > maximumLength)
        {
            return Validation.Failure<string, TError>(
                error
            );
        }

        return Validation.Success<string, TError>(
            value
        );
    }
    // Validates that a DateTime value is not in the future.
    public static ValidationResult<DateTime, TError> NotInFuture<TError>(
        DateTime value,
        DateTime today,
        TError error)
    {
        if (value.Date > today.Date)
        {
            return Validation.Failure<DateTime, TError>(
                error
            );
        }

        return Validation.Success<DateTime, TError>(
            value
        );
    }
    // Validates that a DateTime value is not before the specified minimum date.
    public static ValidationResult<DateTime, TError> NotBefore<TError>(
        DateTime value,
        DateTime minimumDate,
        TError error)
    {
        if (value.Date < minimumDate.Date)
        {
            return Validation.Failure<DateTime, TError>(
                error
            );
        }

        return Validation.Success<DateTime, TError>(
            value
        );
    }
}