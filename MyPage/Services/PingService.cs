using Microsoft.AspNetCore.SignalR;
using MyPage.Hubs;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.SignalR;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyPage.Services
{
    
    public class PingService : BackgroundService
    {
        private readonly IHubContext<PingHub> _hubContext;
        private readonly string _ipAddress = "172.18.96.1"; // Your hardcoded IP

        public PingService(IHubContext<PingHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                Ping ping = new Ping();
                try
                {
                    var result = await ping.SendPingAsync(_ipAddress);
                    if (result.Status == IPStatus.Success)
                    {
                        await _hubContext.Clients.All.SendAsync("ReceivePingResult", $"Ping to {_ipAddress} successful: {result.RoundtripTime} ms");
                    }
                    else
                    {
                        await _hubContext.Clients.All.SendAsync("ReceivePingResult", $"Ping to {_ipAddress} failed: {result.Status}");
                    }
                }
                catch
                {
                    await _hubContext.Clients.All.SendAsync("ReceivePingResult", $"Error pinging {_ipAddress}");
                }
                count += 1;
                Debug.WriteLine(count);
                if(count > 1)
                {
                    await Task.Delay(5000, stoppingToken); // Wait 5 seconds between pings
                }
            }
        }
    }

}
