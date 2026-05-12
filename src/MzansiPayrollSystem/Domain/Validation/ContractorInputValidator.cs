using System.Globalization;
using MzansiPayrollSystem.Domain.Constants;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Validation;

public sealed class ContractorInputValidator : IInputValidator
{
    public ValidationResult Validate(string? contractorName, string? hoursText, string? dependentsText)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(contractorName))
        {
            errors.Add("Contractor name is required.");
        }

        if (string.IsNullOrWhiteSpace(hoursText))
        {
            errors.Add("Hours worked is required.");
        }
        else if (!double.TryParse(hoursText, NumberStyles.Float, CultureInfo.CurrentCulture, out var hours))
        {
            errors.Add("Hours worked must be a valid number.");
        }
        else if (hours < 0)
        {
            errors.Add("Hours worked cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(dependentsText))
        {
            errors.Add("Number of dependents is required.");
        }
        else if (!int.TryParse(dependentsText, NumberStyles.Integer, CultureInfo.CurrentCulture, out var dependents))
        {
            errors.Add("Number of dependents must be a whole number.");
        }
        else if (dependents < 0)
        {
            errors.Add("Number of dependents cannot be negative.");
        }
        else if (dependents > PayrollConstants.MaxDependents)
        {
            errors.Add($"Number of dependents cannot exceed {PayrollConstants.MaxDependents}.");
        }

        return errors.Count == 0 ? ValidationResult.Success() : ValidationResult.WithErrors(errors);
    }

    public ContractorInput BuildInput(string contractorName, string hoursText, string dependentsText)
    {
        var hours = double.Parse(hoursText, NumberStyles.Float, CultureInfo.CurrentCulture);
        var dependents = int.Parse(dependentsText, NumberStyles.Integer, CultureInfo.CurrentCulture);
        return new ContractorInput(contractorName.Trim(), hours, dependents);
    }
}
