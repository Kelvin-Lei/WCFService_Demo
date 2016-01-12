using ResponsiveQueuedService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Service
{
    public class OrderProcessorService : IOrderProcessor
    {
        private void ProcessOrder(Order order)
        {
            if (order.OrderDate < DateTime.Today)
            {
                throw new Exception();
            }
        }

        public void Submit(Order order)
        {
            Console.WriteLine("Begin to process thie order of the order NO.:{0}", order.OrderNo);
            FaultException exception = null;
            if (order.OrderDate < DateTime.Today)
            {
                exception = new FaultException(new FaultReason("The order has expried"), new FaultCode("sender"));
                Console.WriteLine("It's fail to process the order.\n\tOrder No.:{0}\n\tReasion:{1}", order.OrderNo, "The order has expried");
            }
            else
            {
                Console.WriteLine("It's successful to process the order.\n\tOrder No.:{0}", order.OrderNo);
            }

            NetMsmqBinding binding = new NetMsmqBinding();
            binding.ExactlyOnce = false;
            binding.Security.Transport.MsmqAuthenticationMode = MsmqAuthenticationMode.None;
            binding.Security.Transport.MsmqProtectionLevel = ProtectionLevel.None;
            ChannelFactory<IOrderResponse> channelFactory = new ChannelFactory<IOrderResponse>(binding);
            OrderResponseContext responseContext = OrderResponseContext.Current;
            IOrderResponse channel = channelFactory.CreateChannel(new EndpointAddress(responseContext.ResponseAddress));

            using (OperationContextScope contextScope = new OperationContextScope(channel as IContextChannel))
            {
                channel.SubmitOrderResponse(order.OrderNo, exception);
            }
        }
    }
}
