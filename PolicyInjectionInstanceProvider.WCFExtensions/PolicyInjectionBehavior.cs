using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.WCFExtensions
{
    public class PolicyInjectionBehavior : IEndpointBehavior
    {
        private string _policyInjectName;

        public PolicyInjectionBehavior(string policyInjectorName)
        {
            this._policyInjectName = policyInjectorName;
        }



        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            Type serviceContractType = endpoint.Contract.ContractType;
            endpointDispatcher.DispatchRuntime.InstanceProvider = new PolicyInjectionInstanceProvider(serviceContractType, this._policyInjectName);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
