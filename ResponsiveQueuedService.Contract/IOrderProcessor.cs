using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Contract
{
    [ServiceContract]
    [ServiceKnownType(typeof(Order))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay=true)]
        void Submit(Order order);
    }
}
