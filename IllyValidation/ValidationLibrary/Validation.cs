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

    // Combines two validation results into one, aggregating errors if any.
    public static ValidationResult<TResult, TError> Combine<T1, T2, TResult, TError>(
        ValidationResult<T1, TError> result1,
        ValidationResult<T2, TError> result2,
        Func<T1, T2, TResult> createResult)
    {
        var errors = new List<TError>();

        if (result1 is Error<T1, TError> error1)
        {
            errors.AddRange(error1.errors);
        }

        if (result2 is Error<T2, TError> error2)
        {
            errors.AddRange(error2.errors);
        }

        if(errors.Count > 0)
        {
            return new Error<TResult, TError>(errors);
        }

        var firstValue = ((Success<T1, TError>)result1).value;
        var secondValue = ((Success<T2, TError>)result2).value;

        return new Success<TResult, TError>(createResult(firstValue, secondValue));

    }

    // Combines three validation results into one, aggregating errors if any.
    public static ValidationResult<TResult, TError> Combine<T1, T2, T3, TResult, TError>(
        ValidationResult<T1, TError> result1,
        ValidationResult<T2, TError> result2,
        ValidationResult<T3, TError> result3,
        Func<T1, T2, T3, TResult> createResult)
    {
        var errors = new List<TError>();

        if (result1 is Error<T1, TError> error1)
        {
            errors.AddRange(error1.errors);
        }

        if (result2 is Error<T2, TError> error2)
        {
            errors.AddRange(error2.errors);
        }

        if(result3 is Error<T3, TError> error3)
        {
            errors.AddRange(error3.errors);
        }

        if(errors.Count > 0)
        {
            return new Error<TResult, TError>(errors);
        }

        var firstValue = ((Success<T1, TError>)result1).value;
        var secondValue = ((Success<T2, TError>)result2).value;
        var thirdValue = ((Success<T3, TError>)result3).value;

        return new Success<TResult, TError>(createResult(firstValue, secondValue, thirdValue));
    }

}