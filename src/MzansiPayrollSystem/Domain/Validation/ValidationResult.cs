namespace MzansiPayrollSystem.Domain.Validation;

public sealed class ValidationResult
{
    public IReadOnlyList<string> Errors { get; }
    public bool IsValid => Errors.Count == 0;

    private ValidationResult(IReadOnlyList<string> errors) => Errors = errors;

    public static ValidationResult Success() => new(Array.Empty<string>());

    public static ValidationResult WithErrors(IEnumerable<string> errors)
        => new(errors.ToList());
}
