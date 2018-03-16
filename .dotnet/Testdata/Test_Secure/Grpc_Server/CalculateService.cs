using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApplication.Messages;
using Grpc.Core;
using static ConsoleApplication.Messages.CalculateService;

namespace ConsoleApplication
{
    public class CalculateService : CalculateServiceBase
    {
       public override async Task<MathResponse> AddCalcRequest(AddRequest request, ServerCallContext context)
        {
           // Metadata md = context.RequestHeaders;
            return new MathResponse
            {
                Result=request.FirstValue + request.SecondValue
            };


            throw new Exception($"Invalid Operation");
        }
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