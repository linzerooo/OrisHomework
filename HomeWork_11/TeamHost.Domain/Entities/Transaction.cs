using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Transaction: BaseEntity
{
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Amount { get; set; }
    
    /// <summary>
    /// Дата покупки
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// ИД кошелька
    /// </summary>
    public Guid WalletId { get; set; }

    /// <summary>
    /// Кошелёк
    /// </summary>
    public Wallet Wallet { get; set; }
}