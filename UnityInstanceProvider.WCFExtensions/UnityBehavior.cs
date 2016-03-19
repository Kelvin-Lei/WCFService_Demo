using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace UnityInstanceProvider.WCFExtensions
{
    public class UnityBehavior : IEndpointBehavior
    {
        private string _containerName;

        public UnityBehavior(string containerName)
        {
            this._containerName = containerName;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(endpoint.Contract.ContractType, this._containerName);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
