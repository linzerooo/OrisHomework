using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Wallet : BaseEntity
{
    /// <summary>
    /// Свойства кошелька
    /// </summary>
    public decimal Balance { get; set; }
    
    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Связь с информацией о пользователе
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Связь с покупками
    /// </summary>
    public ICollection<Purchase>? Purchases { get; set; }
    
    /// <summary>
    /// Связь с транзакциями
    /// </summary>
    public ICollection<Transaction> Transactions { get; set; }
}