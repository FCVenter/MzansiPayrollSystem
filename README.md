# Mzansi Tech Contractors Payroll System

Windows Forms (.NET 10) payroll application for the SDT621 PM-04 practical.

## Business rules

- Hourly rate: R950.00 per hour
- Gross Pay = Hours Worked × Hourly Rate
- UIF = 1% of Gross Pay
- PAYE = (Gross Pay − (Gross Pay × 0.0575 × Dependents)) × 25%
- Membership Fee = 13% of Gross Pay
- Net Pay = Gross Pay − UIF − PAYE − Membership Fee

## Validation

- Contractor name may not be empty
- Hours worked must be numeric and not negative
- Dependents must be a whole number between 0 and 10

## Running the application

Open `MzansiPayrollSystem.slnx` in Visual Studio 2022 or later, set `MzansiPayrollSystem` as the startup project and press F5.

From the command line:

```
dotnet run --project src/MzansiPayrollSystem
```

## Running the tests

In Visual Studio open the Test Explorer and run all tests, or from the command line:

```
dotnet test
```
