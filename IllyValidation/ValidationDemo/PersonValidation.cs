namespace ValidationDemo;

// Represents the different types of validation errors that can occur for a person's input data.
public enum PersonalValidation
{
    NameRequired,
    NameTooLong,
    DOBRequired,
    DOBCannotBeInFuture,
    DOBCannotBefore1905
}