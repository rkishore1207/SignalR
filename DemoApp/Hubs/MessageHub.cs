using Microsoft.AspNetCore.SignalR;
namespace DemoApp
{
    public class MessageHub:Hub
    {
        public Task SendMessageToAll(string messgae)
        {
            return Clients.All.SendAsync("ReceivedMessage",messgae);
        }
    }
}