using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;

namespace ClientApp
{
    public class Connection
    {
        public async void Start()
        {
            var url = "http://localhost:5000/chatHub";

            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            // receive a message from the hub
            connection.On<string, string>("ReceiveMessage", (user, message) => OnReceiveMessage(user, message));

            var t = connection.StartAsync();

            t.Wait();

            // send a message to the hub
            await connection.InvokeAsync("SendMessage", "From Console", "Hello");
        }

        private void OnReceiveMessage(string user, string message)
        {
            Console.WriteLine($"{user}: {message}");
        }
    }
}