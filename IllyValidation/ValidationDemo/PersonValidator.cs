using ValidationLibrary;


namespace ValidationDemo;

public static class PersonValidator
{
    private const int MaximumNameLength = 100;

    private static readonly DateTime MinimumDOB =
        new DateTime(1905, 1, 1);

// Creates a validator for person input, which checks the name, date of birth, and borough.
    public static Validator<PersonInput, ValidPerson, PersonValidation> Create(
        DateTime? today = null)
     {
        DateTime currentDate = (today ?? DateTime.Today).Date;

        return new Validator<PersonInput, ValidPerson, PersonValidation>(
            input =>
            {
                var nameResult = ValidateName(input.Name);

                var dobResult = ValidateDOB(
                    input.DOB,
                    currentDate
                );

                // Borough is allowed to remain optional.
                var boroughResult =
                    Validation.Success<int?, PersonValidation>(
                        input.Borough
                    );

                return Validation.Combine(
                    nameResult,
                    dobResult,
                    boroughResult,
                    (name, dob, borough) =>
                        new ValidPerson(
                            name,
                            dob,
                            borough
                        )
                );
            }
        );
    }
    
    // Creates a validation result for the name, ensuring it is required and does not exceed the maximum length.
     private static ValidationResult<string, PersonValidation> ValidateName(
        string? name)
    {
        return Rules
            .RequiredText(
                name,
                PersonValidation.NameMustBeEntered
            )
            .Bind(validName =>
                Rules.MaxLength(
                    validName,
                    MaximumNameLength,
                    PersonValidation.NameMaximumLengthExceeded
                )
            );
    }

    // Creates a validation result for the date of birth, ensuring it is required, not in the future, and not before the minimum allowed date.
    private static ValidationResult<DateTime, PersonValidation> ValidateDOB(
        DateTime? dob,
        DateTime today)
    {
        return Rules
            .RequiredValue<DateTime, PersonValidation>(
                dob,
                PersonValidation.DOBMustBeEntered
            )
            .Bind(validDOB =>
                Rules.NotInFuture(
                    validDOB,
                    today,
                    PersonValidation.DOBCannotBeInFuture
                )
            )
            .Bind(validDOB =>
                Rules.NotBefore(
                    validDOB,
                    MinimumDOB,
                    PersonValidation.DOBCannotBeBefore1905
                )
            );
    }
}