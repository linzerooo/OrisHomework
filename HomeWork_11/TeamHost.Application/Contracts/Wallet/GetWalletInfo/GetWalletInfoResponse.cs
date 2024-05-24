using TeamHost.Domain.Entities;

namespace TeamHost.Application.Contracts.Wallet.GetWalletInfo;

public class GetWalletInfoResponse
{
    /// <summary>
    /// Баланс
    /// </summary>
    public decimal Balance { get; set; }
    
    /// <summary>
    /// Покупки
    /// </summary>
    public List<Purchase> Purchases { get; set; }
    
    /// <summary>
    /// Транзакции
    /// </summary>
    public List<Transaction> Transactions { get; set; }
}