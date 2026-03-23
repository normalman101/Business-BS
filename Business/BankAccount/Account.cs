namespace Business.BankAccount;

public class Account : IEntity
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public decimal CurrentBalance { get; } = 0;
    public HashSet<Transaction> Incomes { get; } = [];
    public HashSet<Transaction> Expenses { get; } = [];

    public void AddIncome(Transaction transaction)
    {
        Incomes.Add(transaction);
    }

    public void AddExpense(Transaction transaction)
    {
        Expenses.Add(transaction);
    }
}