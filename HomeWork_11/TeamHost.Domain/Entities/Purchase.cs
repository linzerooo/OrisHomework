using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Purchase : BaseEntity
{
    /// <summary>
    /// Сумма покупки
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
    
    /// <summary>
    /// ИД игры
    /// </summary>
    public Guid GameId { get; set; }
    
    /// <summary>
    /// Игра
    /// </summary>
    public Game Game { get; set; }
}