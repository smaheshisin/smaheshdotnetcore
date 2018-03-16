using ConsoleApplication.Messages;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static ConsoleApplication.Messages.CalculateService;

namespace Grpc.Client
{
    /// <summary>
    /// This class used to call the GRPC service from the server and execute the methods like ADD or Subtract two numbers.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //Declaration
            int number1, number2 = 0;
            string number = "";
            int opt = 0;
            const int port = 9000;

            //Create Insecure GRPC Channel
            var channel = new Channel("localhost", port, SslCredentials.Insecure);
            var client = new CalculateServiceClient(channel);
           
            //Options for Add and subtract GRPC calls
            Console.WriteLine("");
            Console.WriteLine("Options");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("1 --> For Addition");
            Console.WriteLine("2 --> For Subtraction");
            Console.WriteLine("0 --> Exit");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("");

            while (true == true)
            {
                Console.Write("Enter your option: ");

                number = Console.ReadLine();

                Int32.TryParse(number.Trim(), out opt);
                
                if (opt == 1)
                {
                    //Add GRPC Call
                    Console.WriteLine("");
                    Console.WriteLine("Addition");
                    Console.WriteLine("========");

                    Console.Write("Enter Number1                    : ");
                    number = Console.ReadLine();
                    Int32.TryParse(number.Trim(), out number1);

                    Console.Write("Enter Number2                    : ");
                    number = Console.ReadLine();
                    Int32.TryParse(number.Trim(), out number2);

                    //GRPC Service call Add two numbers
                    AddCalcRequestAsync(client, number1, number2).Wait();

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.ReadLine();
                }
                else if (opt == 2)
                {
                    //Add GRPC Call
                    Console.WriteLine("");
                    Console.WriteLine("Subtraction");
                    Console.WriteLine("===========");

                    Console.Write("Enter Number1                    : ");
                    number = Console.ReadLine();
                    Int32.TryParse(number.Trim(), out number1);

                    Console.Write("Enter Number2                    : ");
                    number = Console.ReadLine();
                    Int32.TryParse(number.Trim(), out number2);

                    //GRPC Service call Subtract two numbers
                    SubCalcRequestAsync(client, number1, number2).Wait();

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.ReadLine();
                }
                else if (opt == 0)
                {
                    //Exit
                    break;
                }
            }
        }
        private static async Task AddCalcRequestAsync(CalculateServiceClient client, int number1, int number2)
        {
            var res = await client.AddCalcRequestAsync(new AddRequest()
            {
                FirstValue = number1,
                SecondValue = number2
            });
            Console.WriteLine(res.Result);
        }
        private static async Task SubCalcRequestAsync(CalculateServiceClient client, int number1, int number2)
        {
            var res = await client.SubCalcRequestAsync(new SubRequest()
            {
                FirstValue = number1,
                SecondValue = number2
            });

            Console.WriteLine(res.Result);
        }


    }
}
