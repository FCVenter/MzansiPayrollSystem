namespace MzansiPayrollSystem.Domain.Models;

public sealed class PayrollResult
{
    public required string ContractorName { get; init; }
    public required decimal GrossPay { get; init; }
    public required decimal UifDeduction { get; init; }
    public required decimal PayeDeduction { get; init; }
    public required decimal MembershipFee { get; init; }

    public decimal TotalDeductions => UifDeduction + PayeDeduction + MembershipFee;
    public decimal NetPay => GrossPay - TotalDeductions;
}
