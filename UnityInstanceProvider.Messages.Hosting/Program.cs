using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UnityInstanceProvider.Messages.Service;

namespace UnityInstanceProvider.Messages.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MessageService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Service is started up!");
                };

                host.Open();

                Console.Read();
            }
        }
    }
}
