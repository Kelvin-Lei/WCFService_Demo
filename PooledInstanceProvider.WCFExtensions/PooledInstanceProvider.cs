using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace PooledInstanceProvider.WCFExtensions
{
    public class PooledInstanceProvider : IInstanceProvider
    {

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return PooledInstanceLocator.GetInstanceFromPool(instanceContext.Host.Description.ServiceType);
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            PooledInstanceLocator.ReleaseInstanceToPool(instance as IPooledObject);
        }
    }
}
