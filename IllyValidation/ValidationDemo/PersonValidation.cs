namespace ValidationDemo;


// Represents the different types of validation errors that can occur for a person's input data.
public enum PersonValidation
{
    NameMustBeEntered,
    NameMaximumLengthExceeded,

    DOBMustBeEntered,
    DOBCannotBeInFuture,
    DOBCannotBeBefore1905
}