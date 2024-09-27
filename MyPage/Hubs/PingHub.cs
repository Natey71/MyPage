using Microsoft.AspNetCore.SignalR;

namespace MyPage.Hubs
{
    public class PingHub : Hub
    {
        public async Task SendPingResult(string msg)
        {
            await Clients.All.SendAsync("RecievePingResult", msg);
        }
    }
}
