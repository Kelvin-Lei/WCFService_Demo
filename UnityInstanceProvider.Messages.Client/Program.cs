using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UnityInstanceProvider.Messages.Contract;

namespace UnityInstanceProvider.Messages.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IMessage> channelFactory = new ChannelFactory<IMessage>("messageservice"))
            {
                IMessage messageProxy = channelFactory.CreateChannel();
                Console.WriteLine(messageProxy.GetMessage("HelloWorld"));
            }

            Console.Read();
        }
    }
}
