using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation
{
    public class ContextReceivalBehaviorAttribute : Attribute, IOperationBehavior
    {
        public bool IsBidirectional { get; set; }



        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            dispatchOperation.CallContextInitializers.Add(new ContextReceivalCallContextInitializer(this.IsBidirectional));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
