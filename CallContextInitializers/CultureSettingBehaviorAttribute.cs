﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CallContextInitializers
{
    public class CultureSettingBehaviorAttribute : Attribute, IOperationBehavior
    {

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            dispatchOperation.CallContextInitializers.Add(new CultureSettingCallContextInitializer());
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
