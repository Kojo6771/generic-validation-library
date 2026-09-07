namespace ValidationDemo;

// Represents the input data for a person, including their name, date of birth, and borough.
public sealed record PersonInput(
    string? Name,
    DateTime? DOB,
    int? Borough
);