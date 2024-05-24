using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace TeamHost.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private static readonly List<string> UsersOnline = new List<string>();
    
    /// <inheritdoc />
    public override async Task OnConnectedAsync()
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        UsersOnline.Add(userId!);
        
        await Clients.All.SendAsync("OnConnection", new
        {
            _usersOnline = UsersOnline
        });
    }

    /// <inheritdoc />
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.GetHttpContext()?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        UsersOnline.Remove(userId!);
        await Clients.All
            .SendAsync(
                "OnDisconnected", new
                {
                    userId
                });
    }
}