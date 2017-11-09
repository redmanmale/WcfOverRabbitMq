using System;
using System.ServiceModel;
using System.Threading.Tasks;
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

        public Task<Response> FooBarAsync(Request request) => ExecRemoteMethod(x => x.FooBarAsync(request));

        public Task SayHelloAsync(string hello) => ExecRemoteMethod(x => x.SayHelloAsync(hello));

        public void Dispose() => ((IDisposable)_channelFactory)?.Dispose();

        private async Task<T> ExecRemoteMethod<T>(Func<IWcfOverRabbitMqService, Task<T>> action)
        {
            T remoteMethodResult;
            var proxy = _channelFactory.CreateChannel();

            // ReSharper disable once SuspiciousTypeConversion.Global
            var communicationProxy = (ICommunicationObject)proxy;
            try
            {
                communicationProxy.Open();
                remoteMethodResult = await action(proxy).ConfigureAwait(false);
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

        private async Task ExecRemoteMethod(Func<IWcfOverRabbitMqService, Task> action)
        {
            var proxy = _channelFactory.CreateChannel();

            // ReSharper disable once SuspiciousTypeConversion.Global
            var communicationProxy = (ICommunicationObject)proxy;
            try
            {
                communicationProxy.Open();
                await action(proxy).ConfigureAwait(false);
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
        }
    }
}
