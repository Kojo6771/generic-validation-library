namespace ValidationLibrary;

public static class ValidationResultExtension
{
    // Maps the success value of a ValidationResult to a new value, preserving errors.
    public static ValidationResult<TResult, TError> Map<TSuccess, TResult,TError>(
        this ValidationResult<TSuccess, TError> result,
        Func<TSuccess, TResult> map)
    {
        return result switch
        {
          Success<TSuccess, TError> s => new Success<TResult, TError>(map(s.value)),
          Error<TSuccess, TError> e => new Error<TResult, TError>(e.errors),

          _ => throw new InvalidOperationException("Unknown ValidationResult")
        };
    }



}