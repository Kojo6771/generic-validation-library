namespace ValidationLibrary;

// A static class containing common validation rules.
public static class Rules
{
    // Validates that the given string is not null, empty, or whitespace.
    public static ValidationResult<string, TError> RequiredText<TError>(string? value, TError error)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Validation.Failure<string, TError>(error);
        }
        return Validation.Success<string, TError>(value!);
    }


    // Validates that the given nullable value type has a value.
    public static ValidationResult<T, TError> RequiredValue<T, TError>(T? value, TError error) where T : struct
    {
        if (!value.HasValue)
        {
            return Validation.Failure<T, TError>(error);
        }
        return Validation.Success<T, TError>(value.Value);
    }

    // Validates that the given string does not exceed the specified maximum length.
    public static ValidationResult<string, TError> MaxLength<TError>(
        string value,
        int maximumLength,
        TError error
    )
    {
        if(value.Length > maximumLength)
        {
            return Validation.Failure<string, TError>(error);
        }
        return Validation.Success<string, TError>(value);
    }

}