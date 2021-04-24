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

            PerformanceCounter cpu = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
            // send a message to the hub
            await connection.InvokeAsync("SendMessage", "From Console", "Hello");
        }

        private void OnReceiveMessage(string user, string message)
        {
            Console.WriteLine($"{user}: {message}");
        }
    }
}
           /* ManagementObjectSearcher ramMonitor = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
            PerformanceCounter cpu = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");

            while (true)
            {
                Console.Clear();
                foreach (ManagementObject objram in ramMonitor.Get())
                {
                    ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);
                    ulong freeRam = Convert.ToUInt64(objram["FreePhysicalMemory"]);

                    Console.WriteLine("Свободно памяти {0} МБ / Всего памяти {1} МБ", freeRam / 1024, totalRam / 1024);
                    connection.InvokeAsync("SendMessage", "Свободно памяти {0} МБ:", freeRam / 1024);
                    connection.InvokeAsync("SendMessage", "Всего памяти {0} МБ:", totalRam / 1024);
                }

                foreach (var drive in DriveInfo.GetDrives())
                {
                    Console.WriteLine("Общий объем свободного места, доступного на диске (в байтах): " + drive.TotalFreeSpace);
                    Console.WriteLine("Размер диска (в байтах): " + drive.TotalSize);
                }
                Console.WriteLine("Процессор загружен на: {0}%", cpu.NextValue());

                Thread.Sleep(3000);
            }*/