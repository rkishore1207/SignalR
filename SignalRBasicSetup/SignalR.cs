using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace SignalRBasicSetup
{
    public class SignalR : Hub
    {
        public async Task<int> GetUpdatedCount(int count)
        {
            await Clients.All.SendAsync("updateCount", count);
            return count;
        }
    }
}
