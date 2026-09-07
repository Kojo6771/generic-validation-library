namespace ValidationLibrary;

public static class Validation
{
    // Creates a successful validation result with the specified value.
    public static ValidationResult<TSuccess, TError> Success<TSuccess, TError>(
        TSuccess value)
    {
        return new Success<TSuccess, TError>(value);
    }
    // Creates a failed validation result with the specified errors.
    public static ValidationResult<TSuccess, TError> Failure<TSuccess, TError>(
        params TError[] errors)
    {
        return new Error<TSuccess, TError>(errors);
    }

    // Combines two validation results into one
    public static ValidationResult<TResult, TError> Combine<T1, T2, TResult, TError>(
        ValidationResult<T1, TError> first,
        ValidationResult<T2, TError> second,
        Func<T1, T2, TResult> createResult)
    {
        var errors = new List<TError>();

        if (first is Error<T1, TError> firstError)
        {
            errors.AddRange(firstError.Errors);
        }

        if (second is Error<T2, TError> secondError)
        {
            errors.AddRange(secondError.Errors);
        }

        if (errors.Count > 0)
        {
            return new Error<TResult, TError>(errors);
        }

        var firstValue = ((Success<T1, TError>)first).Value;
        var secondValue = ((Success<T2, TError>)second).Value;

        return new Success<TResult, TError>(
            createResult(firstValue, secondValue)
        );
    }

    // Combines three validation results into one
    public static ValidationResult<TResult, TError> Combine<T1, T2, T3, TResult, TError>(
        ValidationResult<T1, TError> first,
        ValidationResult<T2, TError> second,
        ValidationResult<T3, TError> third,
        Func<T1, T2, T3, TResult> createResult)
    {
        var errors = new List<TError>();

        if (first is Error<T1, TError> firstError)
        {
            errors.AddRange(firstError.Errors);
        }

        if (second is Error<T2, TError> secondError)
        {
            errors.AddRange(secondError.Errors);
        }

        if (third is Error<T3, TError> thirdError)
        {
            errors.AddRange(thirdError.Errors);
        }

        if (errors.Count > 0)
        {
            return new Error<TResult, TError>(errors);
        }

        var firstValue = ((Success<T1, TError>)first).Value;
        var secondValue = ((Success<T2, TError>)second).Value;
        var thirdValue = ((Success<T3, TError>)third).Value;

        return new Success<TResult, TError>(
            createResult(
                firstValue,
                secondValue,
                thirdValue
            )
        );
    }
}