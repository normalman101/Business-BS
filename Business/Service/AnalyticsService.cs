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
}