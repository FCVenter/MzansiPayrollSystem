using MzansiPayrollSystem.Domain.Calculations;
using MzansiPayrollSystem.Domain.Models;

namespace MzansiPayrollSystem.Tests;

[TestClass]
public class PayrollCalculatorTest
{
    public TestContext TestContext { get; set; } = null!;

    private IDeduction _uif = null!;
    private IDeduction _paye = null!;
    private IDeduction _membership = null!;
    private PayrollCalculator _calculator = null!;

    [TestInitialize]
    public void Setup()
    {
        _uif = new UifDeduction();
        _paye = new PayeDeduction();
        _membership = new MembershipDeduction();
        _calculator = new PayrollCalculator(_uif, _paye, _membership);
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void GrossPay_ShouldReturnR9500_WhenHoursWorkedIs10()
    {
        const double hoursWorked = 10;
        const decimal expected = 9500.00m;

        var actual = _calculator.CalculateGrossPay(hoursWorked);

        TestContext.WriteLine($"Testing Gross Pay calculation.");
        TestContext.WriteLine($"Hours Worked: {hoursWorked}");
        TestContext.WriteLine($"Expected Gross Pay: R{expected:N2}");
        TestContext.WriteLine($"Actual Gross Pay:   R{actual:N2}");

        Assert.AreEqual(expected, actual, "Gross pay must equal hours worked multiplied by R950 hourly rate.");
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void UIF_ShouldReturnR100_WhenGrossPayIsR10000()
    {
        const decimal grossPay = 10_000.00m;
        const decimal expected = 100.00m;
        var input = new ContractorInput("Test", 0, 0);

        var actual = _uif.Calculate(input, grossPay);

        TestContext.WriteLine($"Testing UIF calculation (1% of gross pay).");
        TestContext.WriteLine($"Gross Pay: R{grossPay:N2}");
        TestContext.WriteLine($"Expected UIF: R{expected:N2}");
        TestContext.WriteLine($"Actual UIF:   R{actual:N2}");

        Assert.AreEqual(expected, actual, "UIF must equal 1% of gross pay.");
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void MembershipFee_ShouldReturnR1300_WhenGrossPayIsR10000()
    {
        const decimal grossPay = 10_000.00m;
        const decimal expected = 1_300.00m;
        var input = new ContractorInput("Test", 0, 0);

        var actual = _membership.Calculate(input, grossPay);

        TestContext.WriteLine($"Testing Membership Fee calculation (13% of gross pay).");
        TestContext.WriteLine($"Gross Pay: R{grossPay:N2}");
        TestContext.WriteLine($"Expected Membership Fee: R{expected:N2}");
        TestContext.WriteLine($"Actual Membership Fee:   R{actual:N2}");

        Assert.AreEqual(expected, actual, "Membership Fee must equal 13% of gross pay.");
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void PAYE_ShouldReturnR2356_25_WhenGrossPayIsR10000AndDependentsIs1()
    {
        const decimal grossPay = 10_000.00m;
        const decimal expected = 2_356.25m;
        var input = new ContractorInput("Test", 0, Dependents: 1);

        var actual = _paye.Calculate(input, grossPay);

        TestContext.WriteLine($"Testing PAYE calculation: (Gross - Gross * 0.0575 * Dependents) * 25%.");
        TestContext.WriteLine($"Gross Pay: R{grossPay:N2}, Dependents: {input.Dependents}");
        TestContext.WriteLine($"Expected PAYE: R{expected:N2}");
        TestContext.WriteLine($"Actual PAYE:   R{actual:N2}");

        Assert.AreEqual(expected, actual, "PAYE must follow the simplified SARS-based formula.");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public void NetPay_ShouldReturnR4854_50_WhenAllDeductionsAreApplied()
    {
        var input = new ContractorInput("Amina Rizik Selemani", HoursWorked: 8, Dependents: 2);
        const decimal expectedGross = 7_600.00m;
        const decimal expectedUif = 76.00m;
        const decimal expectedPaye = 1_681.50m;
        const decimal expectedMembership = 988.00m;
        const decimal expectedTotalDeductions = 2_745.50m;
        const decimal expectedNetPay = 4_854.50m;

        var result = _calculator.Calculate(input);

        TestContext.WriteLine("Testing full Net Pay calculation with all deductions applied.");
        TestContext.WriteLine($"Hours Worked: {input.HoursWorked}, Dependents: {input.Dependents}");
        TestContext.WriteLine($"Gross Pay:         R{result.GrossPay:N2}  (expected R{expectedGross:N2})");
        TestContext.WriteLine($"UIF:               R{result.UifDeduction:N2}  (expected R{expectedUif:N2})");
        TestContext.WriteLine($"PAYE:              R{result.PayeDeduction:N2}  (expected R{expectedPaye:N2})");
        TestContext.WriteLine($"Membership Fee:    R{result.MembershipFee:N2}  (expected R{expectedMembership:N2})");
        TestContext.WriteLine($"Total Deductions:  R{result.TotalDeductions:N2}  (expected R{expectedTotalDeductions:N2})");
        TestContext.WriteLine($"Calculated Net Pay: R{result.NetPay:N2}  (expected R{expectedNetPay:N2})");

        Assert.AreEqual(expectedGross, result.GrossPay, "Gross pay must match hours * hourly rate.");
        Assert.AreEqual(expectedUif, result.UifDeduction, "UIF must be 1% of gross pay.");
        Assert.AreEqual(expectedPaye, result.PayeDeduction, "PAYE must follow the simplified SARS formula.");
        Assert.AreEqual(expectedMembership, result.MembershipFee, "Membership Fee must be 13% of gross pay.");
        Assert.AreEqual(expectedTotalDeductions, result.TotalDeductions, "Total deductions must equal UIF + PAYE + Membership.");
        Assert.AreEqual(expectedNetPay, result.NetPay, "Net pay must equal gross - total deductions.");
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void GrossPay_ShouldReturnZero_WhenHoursWorkedIsZero()
    {
        var actual = _calculator.CalculateGrossPay(0);

        TestContext.WriteLine("Testing Gross Pay edge case: zero hours worked.");
        TestContext.WriteLine($"Expected: R0.00, Actual: R{actual:N2}");

        Assert.AreEqual(0m, actual, "Gross pay should be zero when no hours are worked.");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public void Calculate_ShouldReducePaye_AsDependentsIncrease()
    {
        var noDependents = _calculator.Calculate(new ContractorInput("A", 10, 0));
        var threeDependents = _calculator.Calculate(new ContractorInput("A", 10, 3));

        TestContext.WriteLine("Testing PAYE rebate behaviour: more dependents should reduce PAYE.");
        TestContext.WriteLine($"PAYE with 0 dependents: R{noDependents.PayeDeduction:N2}");
        TestContext.WriteLine($"PAYE with 3 dependents: R{threeDependents.PayeDeduction:N2}");

        Assert.IsLessThan(noDependents.PayeDeduction, threeDependents.PayeDeduction,
            "PAYE should decrease as the number of dependents increases.");
    }
}
