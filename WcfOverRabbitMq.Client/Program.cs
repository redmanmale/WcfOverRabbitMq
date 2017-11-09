using System;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Client
{
    internal static class Program
    {
        private static void Main()
        {
            var client = new ManagerProxyWrapper("http://localhost/Temporary_Listen_Addresses");

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
