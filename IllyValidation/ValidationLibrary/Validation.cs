namespace ValidationLibrary;

public static class Validation
{
    
    // Validates a value and returns a ValidationResult indicating success or error.
    public static ValidationResult<TSuccess, TError> Success<TSuccess, TError>(TSuccess value)
    {
        return new Success<TSuccess, TError>(value);
    }

    public static ValidationResult<TSuccess, TError> Error<TSuccess, TError>(TError value)
    {
        return new Error<TSuccess, TError>(value);
    }
    
    
}