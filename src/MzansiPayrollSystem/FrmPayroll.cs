using System.Globalization;
using MzansiPayrollSystem.Domain.Calculations;
using MzansiPayrollSystem.Domain.Validation;

namespace MzansiPayrollSystem;

public partial class FrmPayroll : Form
{
    private static readonly CultureInfo ZaCulture = CultureInfo.GetCultureInfo("en-ZA");

    private readonly IPayrollCalculator _calculator;
    private readonly IInputValidator _validator;

    public FrmPayroll(IPayrollCalculator calculator, IInputValidator validator)
    {
        _calculator = calculator;
        _validator = validator;
        InitializeComponent();
    }

    private void OnCalculateClick(object? sender, EventArgs e)
    {
        var validation = _validator.Validate(
            txtContractorName.Text,
            txtHoursWorked.Text,
            txtDependents.Text);

        if (!validation.IsValid)
        {
            MessageBox.Show(
                string.Join(Environment.NewLine, validation.Errors),
                "Invalid input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var input = _validator.BuildInput(
            txtContractorName.Text,
            txtHoursWorked.Text,
            txtDependents.Text);

        var result = _calculator.Calculate(input);

        txtGrossPay.Text = FormatRand(result.GrossPay);
        txtPaye.Text = FormatRand(result.PayeDeduction);
        txtUif.Text = FormatRand(result.UifDeduction);
        txtMembership.Text = FormatRand(result.MembershipFee);
        txtTotalDeductions.Text = FormatRand(result.TotalDeductions);
        txtNetPay.Text = FormatRand(result.NetPay);
    }

    private void OnResetClick(object? sender, EventArgs e)
    {
        txtContractorName.Clear();
        txtHoursWorked.Clear();
        txtDependents.Clear();
        txtGrossPay.Clear();
        txtPaye.Clear();
        txtUif.Clear();
        txtMembership.Clear();
        txtTotalDeductions.Clear();
        txtNetPay.Clear();
        txtContractorName.Focus();
    }

    private void OnExitClick(object? sender, EventArgs e) => Close();

    private static string FormatRand(decimal amount)
        => string.Format(ZaCulture, "R{0:N2}", amount);
}
