using PooledInstanceProvicer.Services;
using PooledInstanceProvider.WCFExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PooledInstanceProvider.Hosting
{
    class Program
    {
        static Timer ScavengingTimer;
        static Timer GCTimer;
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Service has been started up!");
                };

                host.Open();

                ScavengingTimer = new Timer(delegate
                    {
                        PooledInstanceLocator.Scavenge();
                    }, null, 0, 5000);

                GCTimer = new Timer(delegate
                    {
                        GC.Collect();
                    }, null, 0, 1);

                Console.Read();
            }
            
        }
    }
}
