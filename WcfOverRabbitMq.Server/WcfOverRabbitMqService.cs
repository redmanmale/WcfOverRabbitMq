using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class WcfOverRabbitMqService : IWcfOverRabbitMqService
    {
        public Task<Response> FooBarAsync(Request request)
        {
            var response = new Response
            {
                Message = request.Message + " response",
                Result = request.Bar + request.Foo
            };

            Console.WriteLine("Response sent");

            return Task.FromResult(response);
        }

        public Task SayHelloAsync(string hello)
        {
            Console.WriteLine($"Hello, {hello}");

            return Task.CompletedTask;
        }
    }
}
