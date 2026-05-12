using MzansiPayrollSystem.Domain.Validation;

namespace MzansiPayrollSystem.Tests;

[TestClass]
public class ContractorInputValidatorTest
{
    public TestContext TestContext { get; set; } = null!;

    private ContractorInputValidator _validator = null!;

    [TestInitialize]
    public void Setup() => _validator = new ContractorInputValidator();

    [TestMethod]
    [TestCategory("Validation")]
    public void Validate_ShouldFail_WhenContractorNameIsEmpty()
    {
        var result = _validator.Validate("", "10", "2");

        TestContext.WriteLine("Empty contractor name should be rejected.");
        TestContext.WriteLine($"Errors: {string.Join(" | ", result.Errors)}");

        Assert.IsFalse(result.IsValid);
        CollectionAssert.Contains(result.Errors.ToList(), "Contractor name is required.");
    }

    [TestMethod]
    [TestCategory("Validation")]
    public void Validate_ShouldFail_WhenHoursIsNegative()
    {
        var result = _validator.Validate("Amina", "-5", "1");

        TestContext.WriteLine("Negative hours should be rejected.");
        Assert.IsFalse(result.IsValid);
        CollectionAssert.Contains(result.Errors.ToList(), "Hours worked cannot be negative.");
    }

    [TestMethod]
    [TestCategory("Validation")]
    public void Validate_ShouldFail_WhenHoursIsNotNumeric()
    {
        var result = _validator.Validate("Amina", "abc", "1");

        Assert.IsFalse(result.IsValid);
        CollectionAssert.Contains(result.Errors.ToList(), "Hours worked must be a valid number.");
    }

    [TestMethod]
    [TestCategory("Validation")]
    public void Validate_ShouldFail_WhenDependentsExceedTen()
    {
        var result = _validator.Validate("Amina", "10", "11");

        Assert.IsFalse(result.IsValid);
        CollectionAssert.Contains(result.Errors.ToList(), "Number of dependents cannot exceed 10.");
    }

    [TestMethod]
    [TestCategory("Validation")]
    public void Validate_ShouldPass_WhenInputIsValid()
    {
        var result = _validator.Validate("Amina Rizik Selemani", "8", "2");

        TestContext.WriteLine("All fields valid - validator should pass.");
        Assert.IsTrue(result.IsValid);
        Assert.IsEmpty(result.Errors);
    }
}
