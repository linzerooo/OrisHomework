using MediatR;
using TeamHost.Application.Contracts.Wallet.PostChangeBalance;

namespace TeamHost.Application.Features.Queries.Wallet.PostChangeBalance;

public class PostChangeBalanceCommand: PostChangeBalanceRequest, IRequest<bool>
{
    public PostChangeBalanceCommand(PostChangeBalanceRequest request)
        : base(request)
    {
    }
}