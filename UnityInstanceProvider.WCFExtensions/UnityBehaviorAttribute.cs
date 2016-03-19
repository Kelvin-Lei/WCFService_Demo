using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace UnityInstanceProvider.WCFExtensions
{
    public class UnityBehaviorAttribute : Attribute, IContractBehavior
    {
        public string ContainerName { get; set; }



        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = new UnityInstanceProvider(contractDescription.ContractType, this.ContainerName);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
