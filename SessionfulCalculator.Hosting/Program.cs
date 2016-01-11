using SessionfulCalculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SessionfulCalculator.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("The Calculator service has begun to listen ...");
                };
                host.Open();
                Timer timer = new Timer(delegate { GC.Collect(); }, null, 0, 100);
                Console.Read();
            }
        }
    }
}
