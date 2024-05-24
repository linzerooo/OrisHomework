using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using TeamHost.Application.Contracts.Games.GetAllGames;
using TeamHost.Application.Features.Queries.Game.GetAllGames;
using TeamHost.Application.Features.Queries.Game.GetByIdGame;
using TeamHost.Infrastructure.Services;

namespace TeamHost.Areas.Main.Controllers
{
    [Area("Main")]
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;

        public StoreController(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var cachedResult = await _cache.GetRecordAsync<GetAllGamesResponse>("all_games");
            if (cachedResult is not null)
                return View(cachedResult);

            var result = await _mediator.Send(new GetAllGamesQuery());

            await _cache.SetRecordAsync("all_games", result, TimeSpan.FromMinutes(10));

            return View(result);
        }

        [HttpGet("card-store/{id:guid}")]
        public async Task<IActionResult> Details(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdGameQuery(id), cancellationToken);

            return View(result);
        }
    }
}