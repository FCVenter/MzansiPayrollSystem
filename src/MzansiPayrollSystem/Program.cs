using MzansiPayrollSystem.Domain.Calculations;
using MzansiPayrollSystem.Domain.Validation;

namespace MzansiPayrollSystem;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        IPayrollCalculator calculator = new PayrollCalculator(
            uif: new UifDeduction(),
            paye: new PayeDeduction(),
            membership: new MembershipDeduction());

        IInputValidator validator = new ContractorInputValidator();

        Application.Run(new FrmPayroll(calculator, validator));
    }
}
