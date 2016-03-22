using PooledInstanceProvider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PooledInstanceProvider.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IService> channelFactory = new ChannelFactory<IService>("service"))
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0}: invocate service!", i);
                    channelFactory.CreateChannel().DoSomething();
                    Console.WriteLine("Invoke DoSomething Successed!");
                    Thread.Sleep(1000);
                }
            }

            Console.Read();
        }
    }
}
