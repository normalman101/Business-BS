namespace Business.BankAccount;

public class Transaction : IEntity
{
    public Transaction(AccountType accountType, DateOnly dateOnly, decimal total, Guid accountTransactionId)
    {
        AccountType = accountType;
        DateOnly = dateOnly;
        Total = total;
        AccountTransactionId = accountTransactionId;
        Id = Guid.CreateVersion7();
    }

    public AccountType AccountType { get; }
    public DateOnly DateOnly { get; }
    public decimal Total { get; }
    public Guid AccountTransactionId { get; }
    public Guid Id { get; init; }
}