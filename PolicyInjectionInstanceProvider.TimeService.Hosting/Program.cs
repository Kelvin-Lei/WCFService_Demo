using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.TimeService.Hosting
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(PolicyInjectionInstanceProvider.TimeService.Service.TimeService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("Time Service has been started up!");
                };
                host.Open();

                Console.Read();
            }
        }
    }
}
