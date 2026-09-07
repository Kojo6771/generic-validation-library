namespace ValidationDemo;

// Represents a validated person with a non-null name and date of birth, and an optional borough.
public sealed record ValidPerson(
    string Name,
    DateTime DOB,
    int? Borough
);