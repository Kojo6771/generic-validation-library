namespace ValidationLibrary;

public sealed class Validator<TInput, TOutput, TError>
{
    // The function that performs the validation
    private readonly Func<TInput, ValidationResult<TOutput, TError>> _validate;

    // Validator constructor
    public Validator(
        Func<TInput, ValidationResult<TOutput, TError>> validate
    )
    {
        _validate = validate;
    }


    public ValidationResult<TOutput, TError> Validate(TInput input)
    {
        return _validate(input);
    }

    // Maps the output of the validator to a new output type, preserving errors.
    public Validator<TInput, TNewOutput, TError> Map<TNewOutput>(Func<TOutput, TNewOutput> map)
    {
        return new Validator<TInput, TNewOutput, TError>(
            input => _validate(input).Map(map)
        );
    }

    // Chains the current validator with another validator that depends on the output of the current one.
    public Validator<TInput, TNewOutput, TError> AndThen<TNewOutput>(
        Func<TOutput, ValidationResult<TNewOutput, TError>> next)
    {
        return new Validator<TInput, TNewOutput, TError>(
            input => _validate(input).Bind(next)
        );
    }

}