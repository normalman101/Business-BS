namespace Business.BankAccount;

public class Account : IEntity
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public decimal CurrentBalance { get; } = 0;
    public HashSet<Transaction> Incomes { get; } = [];
    public HashSet<Transaction> Expenses { get; } = [];

    /// <summary>
    /// Добавляет доход
    /// </summary>
    /// <param name="transaction">транзакция дохода</param> 
    public void AddIncome(Transaction transaction)
    {
        Incomes.Add(transaction);
    }

    /// <summary>
    /// Добавляет расход
    /// </summary>
    /// <param name="transaction">транзакция расхода</param> 
    public void AddExpense(Transaction transaction)
    {
        Expenses.Add(transaction);
    }
}