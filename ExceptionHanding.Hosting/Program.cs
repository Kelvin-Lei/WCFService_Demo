using ExceptionHandling.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("The Calculator service has begun to listen via the address: {0}", host.BaseAddresses[0]);
                };

                host.Open();
                Console.Read();
            }
        }
    }
}
