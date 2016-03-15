using ContextPropagation.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ContextPropagation.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IContract> channelFactory = new ChannelFactory<IContract>("service"))
            {
                IContract proxy = channelFactory.CreateChannel();
                ApplicationContext.Current.Counter = 100;
                Console.WriteLine("Before service invocation: ApplicationContext.Current.Count = {0}", ApplicationContext.Current.Counter);
                proxy.DoSomething();
                Console.WriteLine("After service invocation: ApplicationContext.Current.Count = {0}", ApplicationContext.Current.Counter);
                Console.Read();
            }
        }
    }
}
