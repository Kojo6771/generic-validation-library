namespace ValidationLibrary;

public static class Validation
{
    
    // Validates a value and returns a ValidationResult indicating success or error.
    public static ValidationResult<TSuccess, TError> Success<TSuccess, TError>(TSuccess value)
    {
        return new Success<TSuccess, TError>(value);
    }


    
}