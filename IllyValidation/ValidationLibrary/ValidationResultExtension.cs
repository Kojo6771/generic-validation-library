namespace ValidationLibrary;

public static class ValidationResultExtensions
{
    // Extension methods for working with validation results.
    public static ValidationResult<TResult, TError> Map<TSuccess, TResult, TError>(
        this ValidationResult<TSuccess, TError> result,
        Func<TSuccess, TResult> map)
    {
        return result switch
        {
            Success<TSuccess, TError> success =>
                new Success<TResult, TError>(
                    map(success.Value)
                ),

            Error<TSuccess, TError> error =>
                new Error<TResult, TError>(
                    error.Errors
                ),

            _ => throw new InvalidOperationException(
                "Unknown validation result."
            )
        };
    }

    // Transforms the value of a successful validation result using the specified mapping function.
    // If the result is an error, it remains unchanged.
    public static ValidationResult<TResult, TError> Bind<TSuccess, TResult, TError>(
        this ValidationResult<TSuccess, TError> result,
        Func<TSuccess, ValidationResult<TResult, TError>> next)
    {
        return result switch
        {
            Success<TSuccess, TError> success =>
                next(success.Value),

            Error<TSuccess, TError> error =>
                new Error<TResult, TError>(
                    error.Errors
                ),

            _ => throw new InvalidOperationException(
                "Unknown validation result."
            )
        };
    }
}