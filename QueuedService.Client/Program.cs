using QueuedService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QueuedService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IOrderProcessor> channelFactory = new ChannelFactory<IOrderProcessor>("defaultEndpoint");
            IOrderProcessor channel = channelFactory.CreateChannel();

            Order order = new Order(Guid.NewGuid(), DateTime.Today, Guid.NewGuid(), "A Company");
            order.OrderItems.Add(new OrderItem(Guid.NewGuid(), "PC", 5000, 20));
            order.OrderItems.Add(new OrderItem(Guid.NewGuid(), "Printer", 7000, 2));

            Console.WriteLine("Submit order to server");

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                channel.Submit(order);
                scope.Complete();
            }
            Console.Read();
        }
    }
}
