using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public interface IPayrollCalculator
{
    decimal CalculateGrossPay(double hoursWorked);
    PayrollResult Calculate(ContractorInput input);
}
