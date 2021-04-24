using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var signalRConnection = new Connection();
            signalRConnection.Start();

            ManagementObjectSearcher ramMonitor = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
            PerformanceCounter cpu = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");

            while (true)
            {
                Console.Clear();
                foreach (ManagementObject objram in ramMonitor.Get())
                {
                    ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);
                    ulong freeRam = Convert.ToUInt64(objram["FreePhysicalMemory"]);

                    Console.WriteLine("Свободно памяти {0} МБ / Всего памяти {1} МБ", freeRam / 1024, totalRam / 1024);
                }

                foreach (var drive in DriveInfo.GetDrives())
                {
                    Console.WriteLine("Общий объем свободного места, доступного на диске (в байтах): " + drive.TotalFreeSpace);
                    Console.WriteLine("Размер диска (в байтах): " + drive.TotalSize);
                }
                Console.WriteLine("Процессор загружен на: {0}%", cpu.NextValue());

                Thread.Sleep(3000);
            }
        }
    }
}
