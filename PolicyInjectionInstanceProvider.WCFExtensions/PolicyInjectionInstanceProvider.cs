using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.WCFExtensions
{
    public class PolicyInjectionInstanceProvider : IInstanceProvider
    {
        private Type _serviceContractType;
        private string _policyInjectorName;

        public PolicyInjectionInstanceProvider(Type serviceContractType, string policyInjectorName)
        {
            this._serviceContractType = serviceContractType;
            this._policyInjectorName = policyInjectorName;
        }



        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            Type serviceType = instanceContext.Host.Description.ServiceType;
            object serviceInstance = Activator.CreateInstance(serviceType);
            if (!this._serviceContractType.IsInterface && !serviceType.IsMarshalByRef && string.IsNullOrEmpty(this._policyInjectorName))
            {
                return serviceInstance;
            }

            return PolicyInjection.Wrap(this._serviceContractType, serviceInstance);

        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            throw new NotImplementedException();
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            throw new NotImplementedException();
        }
    }
}
