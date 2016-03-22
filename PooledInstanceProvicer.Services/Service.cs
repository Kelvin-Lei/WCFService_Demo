using PooledInstanceProvider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PooledInstanceProvicer.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service : IService
    {
        static int count;

        public Service()
        {
            Interlocked.Increment(ref count);
            Console.WriteLine("{0}: Service instance is constructed!", count);
        }



        public void DoSomething()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Service.DoSomething Finished!");
        }

        public bool IsBusy { get; set; }
    }
}
