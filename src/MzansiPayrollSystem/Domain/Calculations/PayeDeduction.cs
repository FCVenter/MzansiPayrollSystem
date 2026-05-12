using MzansiPayrollSystem.Domain.Constants;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public sealed class PayeDeduction : IDeduction
{
    public string Name => "PAYE";

    public decimal Calculate(ContractorInput input, decimal grossPay)
    {
        var rebate = grossPay * PayrollConstants.PayePerDependentRebate * input.Dependents;
        return (grossPay - rebate) * PayrollConstants.PayeRate;
    }
}
