using ResponsiveQueuedService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.LocalService
{
    public class OrderResponseService : IOrderResponse
    {
        public void SubmitOrderResponse(Guid orderNo, FaultException exception)
        {
            if (exception == null)
            {
                Console.WriteLine("It's successful to process the order!\n\tOrder No.:{0}", orderNo);
            }
            else
            {
                Console.WriteLine("It's fail to process the order!\n\tOrder No.:{0}\n\tReason:{1}", orderNo, exception.Message);
            }
        }
    }
}
