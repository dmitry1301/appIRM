using Microsoft.AspNetCore.SignalR;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            SaveToDB(user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        private void SaveToDB(string user, string message)
        {
            
        }
    }
}
