using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Wallet.PostChangeBalance;

public class PostChangeBalanceCommandHandler: IRequestHandler<PostChangeBalanceCommand, bool>
{
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="userContext">Контекст пользователя</param>
    public PostChangeBalanceCommandHandler(
        IDbContext dbContext,
        IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    public async Task<bool> Handle(PostChangeBalanceCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var userFromDb = await _dbContext.Users
            .Include(u => u.Wallet)
            .FirstOrDefaultAsync(u => u.Id == _userContext.CurrentUserId, cancellationToken);

        if (userFromDb is null)
        {
            throw new ArgumentNullException(nameof(userFromDb), "User not found.");
        }

        if (userFromDb.Wallet is null)
        {
            throw new ArgumentNullException(nameof(userFromDb.Wallet), "User wallet not found.");
        }

        userFromDb.Wallet.Balance += request.Amount;

        if (userFromDb.Wallet.Balance > 0)
            userFromDb.Wallet.Balance = 0;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}