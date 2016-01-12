using QueuedService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuedService.Service
{
    public class OrderProcessorService : IOrderProcessor
    {
        public void Submit(Order order)
        {
            Orders.Add(order);
            Console.WriteLine("Receive an order.");
            Console.WriteLine(order.ToString());
        }

    }
}
