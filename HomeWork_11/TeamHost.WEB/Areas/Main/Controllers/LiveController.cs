using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

[Area("Main")]
public class LiveController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public Task<IActionResult> SendStreamUrl(string streamUrl)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}