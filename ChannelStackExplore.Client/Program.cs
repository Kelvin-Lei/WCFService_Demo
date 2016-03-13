using ChannelStackExplore.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ChannelStackExplore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinding binding = new MyBinding();
            IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            channelFactory.Open();

            IRequestChannel channel = channelFactory.CreateChannel(new EndpointAddress("http://127.0.0.1:8888/messagingviabinding"));
            channel.Open();

            Message requestMessage = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://artech.messagingviabinding", "This is a mannually created reply message for the purpose of testing");
            Message replyMessage = channel.Request(requestMessage);
            Console.WriteLine("Receive a reply message:\n{0}", replyMessage);
            channel.Close();
            channelFactory.Close();
            Console.Read();
        }
    }
}
