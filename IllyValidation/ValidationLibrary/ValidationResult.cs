namespace ValidationLibrary;

// Represents the result of a validation operation, which can be either a success or an error.
public abstract record ValidationResult<TSuccess, TError>;

// Represents a successful validation result.
public sealed record Success<TSuccess, TError>(TSuccess Value) : ValidationResult<TSuccess, TError>;

// Represents a failed validation result.
public sealed record Error<TSuccess, TError>(TError[] errors) : ValidationResult<TSuccess, TError>;