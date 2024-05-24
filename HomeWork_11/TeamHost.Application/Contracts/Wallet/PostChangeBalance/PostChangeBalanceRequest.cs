namespace TeamHost.Application.Contracts.Wallet.PostChangeBalance;

public class PostChangeBalanceRequest
{
    public PostChangeBalanceRequest()
    {
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    public PostChangeBalanceRequest(PostChangeBalanceRequest request)
    {
        Amount = request.Amount;
    }

    /// <summary>
    /// Сумма изменения
    /// </summary>
    public decimal Amount { get; set; }
}