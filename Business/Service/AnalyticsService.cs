using Business.BankAccount;

namespace Business.Service;

public class AnalyticsService
{
    public decimal CalculateMonthlyGrossIncome(Account account, uint year, uint month)
    {
        var income = account.Incomes
            .Where(income => income.Date.Year == year && income.Date.Month == month)
            .Sum(income => income.MoneyAmount);
        return income;
    }

    public decimal CalculateMonthlyNetIncome(Account account, uint year, uint month)
    {
        var income = CalculateMonthlyGrossIncome(account, year, month) - CalculateOverallTax(account, year, month);
        return income;
    }
    
    public decimal CalculateMonthlyIndividualTax(Account account, uint year, uint month)
    {
        const decimal rate = 0.04m;
        var incomes = account.Incomes
            .Where(income => 
                income.Date.Year == year &&
                income.Date.Month == month &&
                income.AccountType == AccountType.Individual)
            .Sum(income => income.MoneyAmount);
        var tax = incomes * rate;
        return tax;
    }

    public decimal CalculateMonthlyLegalEntityTax(Account account, uint year, uint month)
    {
        const decimal rate = 0.06m;
        var incomes = account.Incomes
            .Where(income =>
                income.Date.Year == year &&
                income.Date.Month == month &&
                income.AccountType == AccountType.LegalEntity)
            .Sum(income => income.MoneyAmount);
        var tax = incomes * rate;
        return tax;
    }

    public decimal CalculateOverallTax(Account account, uint year, uint month)
    {
        var totalTax = CalculateMonthlyIndividualTax(account, year, month) +
                       CalculateMonthlyLegalEntityTax(account, year, month);
        return totalTax;
    }
}