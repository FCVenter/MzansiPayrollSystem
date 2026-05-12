using MzansiPayrollSystem.Domain.Constants;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public sealed class MembershipDeduction : IDeduction
{
    public string Name => "Membership Fee";

    public decimal Calculate(ContractorInput input, decimal grossPay)
        => grossPay * PayrollConstants.MembershipRate;
}
