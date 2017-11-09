using System.ServiceModel.Channels;
using RabbitMQ.Client;
using RabbitMQ.ServiceModel;

namespace Redmanmale.WcfOverRabbitMq.Common
{
    public static class BindingFactory
    {
        public const string ServiceUri = "soap.amqp:///Temporary_Listen_Addresses";

        public static Binding GetBinding()
        {
            var binding = new RabbitMQBinding("localhost", 5672, "guest", "guest", "/", 8192, Protocols.AMQP_0_9_1);
            return binding;
        }
    }
}
