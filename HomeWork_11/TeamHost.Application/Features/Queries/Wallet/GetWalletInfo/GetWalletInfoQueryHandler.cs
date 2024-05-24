using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Wallet.GetWalletInfo;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Wallet.GetWalletInfo;

/// <summary>
/// Обработчик для <see cref="GetWalletInfoQuery"/>
/// </summary>
public class GetWalletInfoQueryHandler: IRequestHandler<GetWalletInfoQuery, GetWalletInfoResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;

    public GetWalletInfoQueryHandler(IDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    /// <inheritdoc />
    public async Task<GetWalletInfoResponse> Handle(GetWalletInfoQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var wallet = await _dbContext.Wallets
            .Where(w => w.UserId == _userContext.CurrentUserId)
            .FirstAsync(cancellationToken);

        var purchases = await _dbContext.Purchases
            .Where(t => t.WalletId == wallet.Id)
            .Include(t => t.Game)
            .ToListAsync(cancellationToken);

        var transactions = await _dbContext.Transactions
            .Where(t => t.WalletId == wallet.Id)
            .ToListAsync(cancellationToken);

        return new GetWalletInfoResponse
        {
            Balance = wallet.Balance,
            Purchases = purchases,
            Transactions = transactions
        };
    }
}