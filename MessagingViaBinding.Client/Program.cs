using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MessagingViaBinding.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address = new EndpointAddress("http://127.0.0.1:9999/messagingviabinding");
            BasicHttpBinding binding = new BasicHttpBinding();
            IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            channelFactory.Open();
            IRequestChannel channel = channelFactory.CreateChannel(address);
            channel.Open();
            Message requestMessage = Message.CreateMessage(MessageVersion.Soap11, "http://artech/messagingviabinding", "The is a request message manually created for the purpose of testing.");
            Message replyMessage = channel.Request(requestMessage);
            Console.WriteLine("Receive a reply message:\n{0}", replyMessage);
            channel.Close();
            channelFactory.Close();
            Console.Read();
        }
    }
}
