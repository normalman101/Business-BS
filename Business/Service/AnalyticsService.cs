using Business.BankAccount;

namespace Business.Service;

public class AnalyticsService
{
    /// <summary>
    /// Высчитывает месячный доход без вычета налогов и расходов
    /// </summary>
    /// <param name="account">счёт, у которого берётся информация</param>
    /// <param name="year">год для высчитывания дохода</param>
    /// <param name="monthNumber">номер месяца для высчитывания дохода</param>
    /// <returns>Возвращает месячный доход</returns>
    public decimal CalculateMonthlyIncome(Account account, uint year, uint monthNumber)
    {
        var incomes =
            account.Incomes.Where(income => income.DateOnly.Year == year && income.DateOnly.Month == monthNumber);

        return incomes.Sum(income => income.Total);
    }

    /// <summary>
    /// Высчитывает налог дохода с физических лиц
    /// </summary>
    /// <param name="account">счёт, у которого берётся информация</param>
    /// <returns>Возвращает налог</returns>
    public decimal CalculateIndividualAccountTax(Account account)
    {
        const decimal rate = 0.04m;
        var incomes = account.Incomes.Where(income => income.AccountType == AccountType.Individual);
        
        return incomes.Sum(income => income.Total) * rate;
    }

    /// <summary>
    /// Высчитывает налог дохода с юридических лиц
    /// </summary>
    /// <param name="account">счёт, у которого берётся информация</param>
    /// <returns>Возвращает налог</returns>
    public decimal CalculateLegalEntityAccountTax(Account account)
    {
        const decimal rate = 0.06m;
        var incomes = account.Incomes.Where(income => income.AccountType == AccountType.LegalEntity);

        return incomes.Sum(income => income.Total) * rate;
    }

    /// <summary>
    /// Высчитывает итоговый налог по доходам с физических и юридических лиц
    /// </summary>
    /// <param name="account">счёт, у которого будет браться информация</param>
    /// <returns>Возвращает итоговый налог</returns>
    public decimal CalculateTotalTax(Account account)
    {
        return CalculateIndividualAccountTax(account) + CalculateLegalEntityAccountTax(account);
    }

    /// <summary>
    /// Высчитывает доход после вычета налогов и расходов
    /// </summary>
    /// <param name="account">счёт, у которого будет браться информация</param>
    /// <returns>Возвращает доход</returns>
    public decimal CalculateTotalIncome(Account account)
    {
        var income = account.Incomes.Sum(income => income.Total);
        var expenses = account.Expenses.Sum(expense => expense.Total);
        var totalTax = CalculateTotalTax(account);
        return income - totalTax - expenses;
    }
}