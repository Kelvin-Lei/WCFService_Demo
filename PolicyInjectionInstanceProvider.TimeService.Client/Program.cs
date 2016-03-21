using PolicyInjectionInstanceProvider.TimeService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PolicyInjectionInstanceProvider.TimeService.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ITime> channelFactory = new ChannelFactory<ITime>("timeservice"))
            {
                ITime proxy = channelFactory.CreateChannel();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(proxy.GetCurrentTime());
                    Thread.Sleep(1000);
                }
            }

            Console.Read();
        }
    }
}
