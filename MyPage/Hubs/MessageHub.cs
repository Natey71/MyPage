using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace MyPage.Hubs
{
    public class MessageHub : Hub 
    {
        public async Task SendMessage(string user, string message)
        {
            Debug.WriteLine("------------------------------ " + message);
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
           
    }
}
