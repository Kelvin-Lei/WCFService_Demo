using Messages.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MessageService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Message service has been started up!");
                };

                host.Open();

                Console.Read();
            }
        }
    }
}
