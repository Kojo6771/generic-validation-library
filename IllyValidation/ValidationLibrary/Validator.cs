namespace ValidationLibrary;


public sealed class Validator<TInput, TOutput, TError>
{

    private readonly Func<TInput, ValidationResult<TOutput, TError>> _validate;

    // Creates a new validator with the specified validation function.
    public Validator(
        Func<TInput, ValidationResult<TOutput, TError>> validate)
    {
        _validate = validate;
    }

    public ValidationResult<TOutput, TError> Validate(
        TInput input)
    {
        return _validate(input);
    }

    // Creates a validator that transforms the output of the current validation step using the provided mapping function.
    public Validator<TInput, TNewOutput, TError> Map<TNewOutput>(
        Func<TOutput, TNewOutput> map)
    {
        return new Validator<TInput, TNewOutput, TError>(
            input => _validate(input).Map(map)
        );
    }

    // Creates a validator that applies another validation step after the current one, chaining the results.
    public Validator<TInput, TNewOutput, TError> AndThen<TNewOutput>(
        Func<TOutput, ValidationResult<TNewOutput, TError>> next)
    {
        return new Validator<TInput, TNewOutput, TError>(
            input => _validate(input).Bind(next)
        );
    }
}