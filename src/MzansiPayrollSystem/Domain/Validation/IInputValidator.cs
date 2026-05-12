using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Validation;

public interface IInputValidator
{
    ValidationResult Validate(string? contractorName, string? hoursText, string? dependentsText);

    ContractorInput BuildInput(string contractorName, string hoursText, string dependentsText);
}
