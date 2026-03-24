namespace Business.BankAccount;

/// <summary>
/// Класс, описывающий транзакцию
/// </summary>
public class Transaction : IEntity
{
    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="debitedAccount">Списывающий счёт</param>
    /// <param name="moneyAmount">сумма денег</param>
    /// <exception cref="Exception">вызывается, когда значение moneyAmount равен нулю</exception>
    public Transaction(Account debitedAccount, decimal moneyAmount)
    {
        Id = Guid.CreateVersion7();
        DebitedAccountId = debitedAccount.Id;
        AccountType = debitedAccount.AccountType;
        Date = DateOnly.FromDateTime(DateTime.Today);
        MoneyAmount = moneyAmount != 0m ? moneyAmount : throw new Exception("Can't make the transaction when money amount is null");
    }

    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    public Guid Id { get; }
    /// <summary>
    /// Идентификатор списывающего счёта
    /// </summary>
    public Guid DebitedAccountId { get; }
    /// <summary>
    /// Лицо
    /// </summary>
    public AccountType AccountType { get; }
    /// <summary>
    /// Дата транзакции
    /// </summary>
    public DateOnly Date { get; }
    /// <summary>
    /// Сумма денег
    /// </summary>
    public decimal MoneyAmount { get; }
}