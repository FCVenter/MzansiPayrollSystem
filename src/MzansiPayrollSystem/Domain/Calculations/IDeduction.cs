using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public interface IDeduction
{
    string Name { get; }
    decimal Calculate(ContractorInput input, decimal grossPay);
}
