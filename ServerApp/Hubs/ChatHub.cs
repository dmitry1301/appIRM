using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ServerApp.Models;
using ServerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        IUserRepository repository;
        public ChatHub(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task Send(string message, string userName)
        {
            repository.AddUser(new User { UserName = userName, Message = message });
            await Clients.All.SendAsync("Receive", message, userName);
        }
        [Authorize(Roles = "admin")]
        public async Task Notify(string message, string userName)
        {
            repository.AddUser(new User { UserName = userName, Message = message });
            await Clients.All.SendAsync("Receive", message, userName);
        }
    }
}
