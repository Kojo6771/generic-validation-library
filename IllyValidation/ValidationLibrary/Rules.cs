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
}