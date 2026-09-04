namespace ValidationLibrary;

public static class Validation
{
    
    // Validates a value and returns a ValidationResult indicating success or error.
    public static ValidationResult<TSuccess, TError> Success<TSuccess, TError>(TSuccess value)
    {
        return new Success<TSuccess, TError>(value);
    }

    public static ValidationResult<TSuccess, TError> Error<TSuccess, TError>(TError[] errors)
    {
        return new Error<TSuccess, TError>(errors);
    }
    
    public static ValidationResult<TResult, TError> Combine<T1, T2, TResult, TError>(
        ValidationResult<T1, TError> result1,
        ValidationResult<T2, TError> result2,
        Func<T1, T2, TResult> createResult)
    {
        var error = new List<TError>();

        if (result1 is Error<T1, TError> error1)
        {
            error.AddRange(error1.errors);
        }

        if (result2 is Error<T2, TError> error2)
        {
            error.AddRange(error2.errors);
        }

        
    }
}