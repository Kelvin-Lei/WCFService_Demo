using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Contract
{
    [ServiceContract]
    public interface IOrderResponse
    {
        [OperationContract(IsOneWay=true)]
        void SubmitOrderResponse(Guid orderNo, FaultException exception);
    }
}
