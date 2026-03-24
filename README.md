```mermaid
classDiagram
    class IEntity {
        <<Interface>>
        #Guid _id
        #GetId() Guid
    }
    IEntity <|.. Transaction
    IEntity <|.. Account

    namespace BankAccount {
        class AccountType {
            <<Enum>>
            +Individual
            +LegalEntity
        }

        class Transaction {
            -DateOnly _date
            -decimal _moneyAmount
            -Guid _debitedAccountId
            +Transaction(Guid debitedAccountId, decimal total) void
            +GetId() Guid
            +GetDate() DateOnly
            +GetMoneyAmount() decimal
            +GetDebitedAccountId() Guid
        }

        class Account {
            -AccountType _accountType
            -decimal _currentBalance
            -HashSet~Transaction~ _incomes
            +Account(AccountType accountType) void
            +GetId() Guid
            +GetAccountType() AccountType
            +GetCurrentBalance() decimal
            +GetIncomes() HashSet~Transaction~
            +AddIncome(Transaction transaction) void
        }
    }
    AccountType <--* Account


    namespace Service {
        class AnalyticsService {
            +CalculateMonthlyGrossIncome(Account account, uint year, uint monthNumber) decimal
            +CalculateMonthlyNetIncome(Account account, uint year, uint monthNumber) decimal
            +CalculateMonthlyIndividualTax(Account account, uint year, uint monthNumber) decimal
            +CalculateLegalEntityTax(Account account, uint year, uint monthNumber) decimal
            +CalculateOverallTax(Account account, uint year, uint monthNumber) decimal
        }
    }
    Account <-- AnalyticsService
```

Интерфейс **IEntity** — используется для задания соблюдения контракта у наследника.

Перечисление **AccountType** — используется для задания лица счета.

Класс **Transaction** — используется для создания транзакции дохода или расхода.

Класс **Account** — используется для создания счёта.
Методы:
- **AddIncome(Transaction transaction)** — добавляет доход.
- **AddExpense(Transaction transaction)** — добавляет расход.

Класс **AnalyticsService** — используется для аналитики доходов счёта.
Методы:
- CalculateMonthlyIncome(Account account, uint year, uint monthNumber) — Высчитывает месячный доход без вычета налогов и расходов.
- CalculateIndividualAccountTax(Account account) — Высчитывает налог дохода с физических лиц.
- CalculateLegalEntityAccountTax(Account account) — Высчитывает налог дохода с юридических лиц.
- CalculateTotalTax(Account account) — Высчитывает итоговый налог по доходам с физических и юридических лиц.
- CalculateTotalIncome(Account account) — Высчитывает доход после вычета налогов и расходов.
