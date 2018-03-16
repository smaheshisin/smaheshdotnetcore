using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication;
using Grpc.Core;
using static ConsoleApplication.Messages.CalculateService;

namespace Grpc.Server
{
    /// <summary>
    /// This class used to start the GRPC service in locahost for the given port
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration
            const int port = 9000;
           

            //Bind GRPC Services
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) },
                Services = { BindService(new CalculateService()) }
            };

            //Start the GRPC server
            server.Start();

            Console.WriteLine("Starting server on port " + port);
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
