using PooledInstanceProvider.WCFExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PooledInstanceProvider.Contracts
{
    [ServiceContract]
    [PooledInstanceBehavior]
    public interface IService : IPooledObject
    {
        [OperationContract(IsOneWay = true)]
        void DoSomething();
    }
}
