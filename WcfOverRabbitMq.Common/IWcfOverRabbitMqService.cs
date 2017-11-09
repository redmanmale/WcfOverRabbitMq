using System.ServiceModel;

namespace Redmanmale.WcfOverRabbitMq.Common
{
    [ServiceContract]
    public interface IWcfOverRabbitMqService
    {
        [OperationContract]
        Response FooBar(Request request);
    }
}
