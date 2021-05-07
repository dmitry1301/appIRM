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
        }
    }
}
