namespace ValidationLibrary;


public abstract record ValidationResult<TSuccess, TError>;

public sealed record Success<TSuccess, TError>(TSuccess Value) : ValidationResult<TSuccess, TError>;
public sealed record Error<TSuccess, TError>(TError Value) : ValidationResult<TSuccess, TError>;