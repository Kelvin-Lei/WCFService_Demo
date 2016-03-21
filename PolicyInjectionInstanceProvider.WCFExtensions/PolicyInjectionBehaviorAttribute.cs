using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.WCFExtensions
{
    public class PolicyInjectionBehaviorAttribute : Attribute, IContractBehavior
    {
        public string PolicyInjectorName { get; set; }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            Type serviceContractType = contractDescription.ContractType;
            dispatchRuntime.InstanceProvider = new PolicyInjectionInstanceProvider(serviceContractType, this.PolicyInjectorName);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
