using System;
using System.ServiceModel;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class WcfOverRabbitMqService : IWcfOverRabbitMqService
    {
        public Response FooBar(Request request)
        {
            var response = new Response
            {
                Message = request.Message + " response",
                Result = request.Bar + request.Foo
            };

            Console.WriteLine("Response sent");

            return response;
        }
    }
}
