using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication;
using Grpc.Core;
using static ConsoleApplication.Messages.CalculateService;

namespace Grpc.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration
            const int port = 9000;
           
            //Create Server Certificates
            var cert = File.ReadAllText("Keys/server.crt");
            var key = File.ReadAllText("Keys/server.key");

            var keypair = new KeyCertificatePair(cert, key);

            //Create SSL Certificate for Server
            var sslCreds = new SslServerCredentials(new List<KeyCertificatePair>
            {
                keypair
            }, cert, false);
            

            //Bind GRPC Services
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Ports = { new ServerPort("localhost", port, sslCreds) },
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
