using System;
using System.ServiceModel;
using Redmanmale.WcfOverRabbitMq.Common;

namespace Redmanmale.WcfOverRabbitMq.Client
{
    internal class ManagerProxyWrapper : IWcfOverRabbitMqService, IDisposable
    {
        private readonly ChannelFactory<IWcfOverRabbitMqService> _channelFactory;

        public ManagerProxyWrapper(string uri)
        {
            _channelFactory = new ChannelFactory<IWcfOverRabbitMqService>(BindingFactory.GetBinding(), uri);
        }

        public Response FooBar(Request request)
        {
            return ExecRemoteMethod(x => x.FooBar(request));
        }

        public void Dispose()
        {
            ((IDisposable)_channelFactory)?.Dispose();
        }

        private T ExecRemoteMethod<T>(Func<IWcfOverRabbitMqService, T> action)
        {
            T remoteMethodResult;
            var proxy = _channelFactory.CreateChannel();
            
            // ReSharper disable once SuspiciousTypeConversion.Global
            var communicationProxy = (ICommunicationObject)proxy;
            try
            {
                communicationProxy.Open();
                remoteMethodResult = action(proxy);
            }
            catch (Exception e)
            {
                throw new Exception("Operation failed. Unknown error.", e);
            }
            finally
            {
                if (communicationProxy.State == CommunicationState.Opened)
                {
                    communicationProxy.Close();
                }
                else
                {
                    communicationProxy.Abort();
                }
            }
            return remoteMethodResult;
        }
    }
}
