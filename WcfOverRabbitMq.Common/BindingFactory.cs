using System.ServiceModel;

namespace Redmanmale.WcfOverRabbitMq.Common
{
    public static class BindingFactory
    {
        public static WebHttpBinding GetBinding()
        {
            var binding = new WebHttpBinding
            {
                MaxBufferPoolSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferSize = int.MaxValue
            };

            return binding;
        }
    }
}
