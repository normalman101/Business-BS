namespace Business.BankAccount;

/// <summary>
/// Класс, описывающий счёт
/// </summary>
/// <param name="accountType">тип счёта</param>
public class Account(AccountType accountType) : IEntity
{
    /// <summary>
    /// Идентификатор счёта
    /// </summary>
    public Guid Id { get; init; } = Guid.CreateVersion7();
    /// <summary>
    /// Тип счёта
    /// </summary>
    public AccountType AccountType { get; } = accountType; 
    /// <summary>
    /// Текущий баланс
    /// </summary>
    public decimal CurrentBalance { get; private set; } = 0m;

    private readonly HashSet<Transaction> _incomes = [];
    /// <summary>
    /// Транзакции прибыли
    /// </summary>
    public HashSet<Transaction> Incomes { get => _incomes.ToHashSet(); }

    /// <summary>
    /// Добавляет доход
    /// </summary>
    /// <param name="transaction">транзакция дохода</param> 
    public void AddIncome(Transaction transaction)
    {
        Incomes.Add(transaction);
        CurrentBalance += transaction.MoneyAmount;
    }
}