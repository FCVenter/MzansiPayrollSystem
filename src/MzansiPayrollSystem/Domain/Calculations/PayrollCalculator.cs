using MzansiPayrollSystem.Domain.Constants;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Domain.Calculations;

public sealed class PayrollCalculator : IPayrollCalculator
{
    private readonly IDeduction _uif;
    private readonly IDeduction _paye;
    private readonly IDeduction _membership;

    public PayrollCalculator(IDeduction uif, IDeduction paye, IDeduction membership)
    {
        _uif = uif;
        _paye = paye;
        _membership = membership;
    }

    public decimal CalculateGrossPay(double hoursWorked)
        => (decimal)hoursWorked * PayrollConstants.HourlyRate;

    public PayrollResult Calculate(ContractorInput input)
    {
        var gross = CalculateGrossPay(input.HoursWorked);

        return new PayrollResult
        {
            ContractorName = input.ContractorName,
            GrossPay = gross,
            UifDeduction = _uif.Calculate(input, gross),
            PayeDeduction = _paye.Calculate(input, gross),
            MembershipFee = _membership.Calculate(input, gross),
        };
    }
}
