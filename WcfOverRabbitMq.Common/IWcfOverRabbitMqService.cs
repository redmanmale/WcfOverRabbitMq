using System.ServiceModel;
using System.Threading.Tasks;

namespace Redmanmale.WcfOverRabbitMq.Common
{
    [ServiceContract]
    public interface IWcfOverRabbitMqService
    {
        [OperationContract]
        Task<Response> FooBar(Request request);
    }
}
