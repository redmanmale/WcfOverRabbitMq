using System;
using System.ServiceModel.Web;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Server
{
    internal static class Program
    {
        private static void Main()
        {
            var wcfOverRabbitMqService = new WcfOverRabbitMqService();
            var wcfOverRabbitMqServiceHost = new WebServiceHost(wcfOverRabbitMqService);

            wcfOverRabbitMqServiceHost.AddServiceEndpoint(typeof(IWcfOverRabbitMqService), BindingFactory.GetBinding(), BindingFactory.ServiceUri);
            wcfOverRabbitMqServiceHost.Open();

            Console.WriteLine("Running...");
            Console.ReadLine();

            wcfOverRabbitMqServiceHost.Close();
        }
    }
}
