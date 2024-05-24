using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Contracts.Wallet.PostChangeBalance;
using TeamHost.Application.Features.Queries.Wallet.GetWalletInfo;
using TeamHost.Application.Features.Queries.Wallet.PostChangeBalance;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
[Authorize]
public class WalletController : Controller
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var walletInfo = await _mediator.Send(new GetWalletInfoQuery(), cancellationToken);
        return View(walletInfo);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeBalance([FromForm] PostChangeBalanceRequest request,[FromForm] string operation, CancellationToken cancellationToken)
    {
        // Проверяем валидность операции
        if (operation != "deposit" && operation != "withdraw")
            return BadRequest("Invalid operation.");

        // Проверяем, что сумма неотрицательная для операции снятия
        if (request.Amount < 0 && operation.Equals("withdraw"))
            return BadRequest("Amount should be positive for withdrawal operation.");

        var result = await _mediator.Send(new PostChangeBalanceCommand(request), cancellationToken);

        if (!result)
            return BadRequest("Failed to change balance.");

        return RedirectToPage("Index");
    }
}