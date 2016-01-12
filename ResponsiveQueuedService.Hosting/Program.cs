using ResponsiveQueuedService.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveQueuedService.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["msmqPath"];
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }

            using (ServiceHost host = new ServiceHost(typeof(OrderProcessorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("The Order Processor service has begun to listen ...");
                };

                host.Open();
                Console.Read();
            }
        }
    }
}
