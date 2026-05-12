using MzansiPayrollSystem.Domain.Constants;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public sealed class UifDeduction : IDeduction
{
    public string Name => "UIF";

    public decimal Calculate(ContractorInput input, decimal grossPay)
        => grossPay * PayrollConstants.UifRate;
}
