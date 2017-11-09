using System;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Client
{
    internal static class Program
    {
        private static void Main()
        {
            var client = new ManagerProxyWrapper(BindingFactory.ServiceUri);

            var request = new Request
            {
                Message = "Hooray!",
                Bar = 100500,
                Foo = 1
            };

            Console.WriteLine("Request sent");

            var response = client.FooBar(request);
            Console.WriteLine(response);

            Console.ReadLine();
        }
    }
}
