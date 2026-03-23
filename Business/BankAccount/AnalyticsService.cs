namespace Business.BankAccount;

public class AnalyticsService
{
    public decimal CalculateMonthlyIncome(Account account, uint year, uint monthNumber)
    {
        var incomes =
            account.Incomes.Where(income => income.DateOnly.Year == year && income.DateOnly.Month == monthNumber);

        return incomes.Sum(income => income.Total);
    }

    public decimal CalculateIndividualAccountTax(Account account)
    {
        const decimal rate = 0.04m;
        var incomes = account.Incomes.Where(income => income.AccountType == AccountType.Individual);
        
        return incomes.Sum(income => income.Total) * rate;
    }

    public decimal CalculateLegalEntityAccountTax(Account account)
    {
        const decimal rate = 0.06m;
        var incomes = account.Incomes.Where(income => income.AccountType == AccountType.LegalEntity);

        return incomes.Sum(income => income.Total) * rate;
    }

    public decimal CalculateTotalTax(Account account)
    {
        return CalculateIndividualAccountTax(account) + CalculateLegalEntityAccountTax(account);
    }

    public decimal CalculateTotalIncome(Account account)
    {
        var income = account.Incomes.Sum(income => income.Total);
        var expenses = account.Expenses.Sum(expense => expense.Total);
        var totalTax = CalculateTotalTax(account);
        return income - totalTax - expenses;
    }
}