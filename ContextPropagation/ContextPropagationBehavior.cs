using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation
{
    public class ContextPropagationBehavior : IEndpointBehavior
    {
        public bool IsBidirectional { get; set; }

        public ContextPropagationBehavior() : this(false) 
        {
        }

        public ContextPropagationBehavior(bool isBidirectional)
        {
            this.IsBidirectional = isBidirectional;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new ContextAttachmentMessageInspector(this.IsBidirectional));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            foreach (var operation in endpointDispatcher.DispatchRuntime.Operations)
            {
                operation.CallContextInitializers.Add(new ContextReceivalCallContextInitializer(this.IsBidirectional));
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
