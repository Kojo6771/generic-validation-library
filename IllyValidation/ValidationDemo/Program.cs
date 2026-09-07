using ValidationDemo;
using ValidationLibrary;

var validator = PersonValidator.Create();

var examples = new[]
{
    new PersonInput(
        Name: "Kwadwo",
        DOB: new DateTime(2001, 11, 26),
        Borough: 1
    ),

    new PersonInput(
        Name: null,
        DOB: new DateTime(2000, 5, 20),
        Borough: null
    ),

    new PersonInput(
        Name: "Kwadwo",
        DOB: DateTime.Today.AddYears(1),
        Borough: 2
    ),

    new PersonInput(
        Name: null,
        DOB: DateTime.Today.AddYears(1),
        Borough: null
    ),

    new PersonInput(
        Name: "Someone",
        DOB: new DateTime(1900, 1, 1),
        Borough: null
    )
};

foreach (var person in examples)
{
    Console.WriteLine("----------------------------");
    Console.WriteLine($"Input: {person}");

    var result = validator.Validate(person);

    PrintResult(result);

    Console.WriteLine();
}

static void PrintResult(
    ValidationResult<ValidPerson, PersonValidation> result)
{
    switch (result)
    {
        case Success<ValidPerson, PersonValidation> success:
            Console.WriteLine("VALID");
            Console.WriteLine($"Name: {success.Value.Name}");
            Console.WriteLine($"DOB: {success.Value.DOB:d}");
            Console.WriteLine(
                $"Borough: {success.Value.Borough?.ToString() ?? "Not supplied"}"
            );
            break;

        case Error<ValidPerson, PersonValidation> failure:
            Console.WriteLine("INVALID");

            foreach (var error in failure.Errors)
            {
                Console.WriteLine($"- {error}");
            }

            break;
    }
}