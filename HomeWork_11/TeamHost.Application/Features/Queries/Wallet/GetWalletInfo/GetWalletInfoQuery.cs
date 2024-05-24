using MediatR;
using TeamHost.Application.Contracts.Wallet.GetWalletInfo;

namespace TeamHost.Application.Features.Queries.Wallet.GetWalletInfo;

/// <summary>
/// Запрос на получение баланса пользователя
/// </summary>
public class GetWalletInfoQuery: IRequest<GetWalletInfoResponse>
{
}