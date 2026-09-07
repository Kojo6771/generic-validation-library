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
}