using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApplication.Messages;
using Grpc.Core;
using static ConsoleApplication.Messages.CalculateService;

namespace ConsoleApplication
{
    //Create GRPC Service call for Add and Subtract two numbers
    public class CalculateService : CalculateServiceBase
    {
        /// <summary>
        /// This method used to add two numbers and return the resulted value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
       public override async Task<MathResponse> AddCalcRequest(AddRequest request, ServerCallContext context)
        {
            return new MathResponse
            {
                Result=request.FirstValue + request.SecondValue
            };


            throw new Exception($"Invalid Operation");
        }
        /// <summary>
        /// This method used to subtract two numbers and return the resulted value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<MathResponse> SubCalcRequest(SubRequest request, ServerCallContext context)
        {
           // Metadata md = context.RequestHeaders;
            return new MathResponse
            {
                Result=request.FirstValue - request.SecondValue
            };


            throw new Exception($"Invalid Operation");
        }

    }

}