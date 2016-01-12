using ResponsiveQueuedService.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(Guid.NewGuid(), DateTime.Today.AddDays(5), Guid.NewGuid(), "Supplier A");
            Order order2 = new Order(Guid.NewGuid(), DateTime.Today.AddDays(-5), Guid.NewGuid(), "Supplier A");

            string path = ConfigurationManager.AppSettings["msmqPath"];
            Uri address = new Uri(path);
            OrderResponseContext context = new OrderResponseContext();
            context.ResponseAddress = address;

            ChannelFactory<IOrderProcessor> channelFactory = new ChannelFactory<IOrderProcessor>("defaultEndpoint");
            IOrderProcessor orderProcessor = channelFactory.CreateChannel();

            using (OperationContextScope contextScope = new OperationContextScope(orderProcessor as IContextChannel))
            {
                Console.WriteLine("Submit the order of order No.:{0}", order1.OrderNo);
                OrderResponseContext.Current = context;
                orderProcessor.Submit(order1);
            }

            using (OperationContextScope contextScope = new OperationContextScope(orderProcessor as IContextChannel))
            {
                Console.WriteLine("Submit the order of order No.:{0}", order2.OrderNo);
                OrderResponseContext.Current = context;
                orderProcessor.Submit(order2);
            }
            Console.Read();
        }
    }
}
