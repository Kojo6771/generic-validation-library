using ValidationLibrary;

namespace ValidationDemo;

public static class PersonValidator
{
    private const int MaximumNameLength = 100;

    private static readonly DateTime MinimumDOB =
        new DateTime(1905, 1, 1);

    public static Validator<PersonInput, ValidPerson, PersonValidation> Create(
        DateTime? today = null){}
}