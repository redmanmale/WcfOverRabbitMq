using System;
using System.Threading.Tasks;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Client
{
    internal static class Program
    {
        private static void Main()
        {
            FooBar().Wait();
            Console.ReadLine();
        }

        private static async Task FooBar()
        {
            using (var client = new ManagerProxyWrapper(BindingFactory.ServiceUri))
            {
                var request = new Request
                {
                    Message = "Hooray!",
                    Bar = 100500,
                    Foo = 1
                };

                Console.WriteLine("Request sent");

                var response = await client.FooBar(request).ConfigureAwait(false);
                Console.WriteLine(response);
            }
        }
    }
}
