using Messages.Contract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messages.Client
{
    class Program
    {
        private const string CultureInfoHeadLocalName = "__CultureInfo";
        private const string CultureInfoHeaderNamespace = "urn:artech.com";
        static void Main(string[] args)
        {
            using (ChannelFactory<IMessage> channelFactory = new ChannelFactory<IMessage>("messageservice"))
            {
                IMessage proxy = channelFactory.CreateChannel();
                using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                {
                    MessageHeader<CultureInfo> header = new MessageHeader<CultureInfo>(Thread.CurrentThread.CurrentUICulture);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header.GetUntypedHeader(CultureInfoHeadLocalName, CultureInfoHeaderNamespace));
                    Console.WriteLine("The UI culture of current thread is {0}", Thread.CurrentThread.CurrentUICulture);
                    Console.WriteLine(proxy.GetMessage());
                }

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                {
                    MessageHeader<CultureInfo> header = new MessageHeader<CultureInfo>(Thread.CurrentThread.CurrentUICulture);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header.GetUntypedHeader(CultureInfoHeadLocalName, CultureInfoHeaderNamespace));
                    Console.WriteLine("The UI culture of current thread is {0}", Thread.CurrentThread.CurrentUICulture);
                    Console.WriteLine(proxy.GetMessage());
                }
            }

            Console.Read();
        }
    }
}
